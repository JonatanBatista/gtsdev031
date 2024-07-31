using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Filtering;
using Tekla.Structures.Filtering.Categories;

using System.IO;
using System.Text;
using System.Linq;
using System.Reflection.Emit;

namespace WinBoltAttribute
{
    public partial class MainForm : Form
    {
        private readonly Model MyModel;
        private readonly GraphicsDrawer graphicsDrawer;
       
        public MainForm()
        {
            InitializeComponent();
            MyModel = new Model();
            graphicsDrawer = new GraphicsDrawer();
            logger.WriteLog("Aplicativo Iniciado");

            year.Text = Convert.ToString(ano);
            day.Text = Convert.ToString(dia);
            month.Text = Convert.ToString(mes);

        }

        private List<BoltGroup> TeklaEnumToBoltList(ModelObjectEnumerator MyEnum)
        {
            pgrbarParts.Maximum = MyEnum.GetSize();
            pgrbarParts.Visible = true;

            var myList = new List<BoltGroup>();
            while (MyEnum.MoveNext())
            {
                if (MyEnum.Current is BoltGroup)
                {
                    var part = (BoltGroup)MyEnum.Current;

                    myList.Add(part);
                }
                pgrbarParts.PerformStep();
            }

            pgrbarParts.Visible = false;
            return myList;
        } 
        
        private List<BoltGroup> getSelectedBolts()
        {
            if (MyModel.GetConnectionStatus())
            {
                var MyEnum = new Tekla.Structures.Model.UI.ModelObjectSelector().GetSelectedObjects();
                return TeklaEnumToBoltList(MyEnum);
            }
            else
            {
                MessageBox.Show("Can't connect to Model.");
                logger.WriteLog("Não foi possível conectar ao modelo!");
                return null;
            }
        } 
         
        private List<BoltGroup> getAllBolts()
        {
            var myList = new List<string>();
            if (MyModel.GetConnectionStatus())
            {
                var objType = new ObjectFilterExpressions.Type();
                var type = new NumericConstantFilterExpression(Tekla.Structures.TeklaStructuresDatabaseTypeEnum.BOLT);

                var expression = new BinaryFilterExpression(objType, NumericOperatorType.IS_EQUAL, type);

                var filterCollection = new BinaryFilterExpressionCollection
                {
                    new BinaryFilterExpressionItem(expression)
                };

                ModelObjectEnumerator.AutoFetch = true;
                var myEnum = MyModel.GetModelObjectSelector().GetObjectsByFilter(filterCollection);


                return TeklaEnumToBoltList(myEnum);
            }
            else
            {
                MessageBox.Show("Can't connect to Model.");
                logger.WriteLog("Não foi possível conectar ao modelo!");
                return null;
            }
        }
         




        


        private List<Part> TeklaEnumToPartList(ModelObjectEnumerator MyEnum)
        {
            pgrbarParts.Maximum = MyEnum.GetSize();
            pgrbarParts.Visible = true;

            var myList = new List<Part>();
            while (MyEnum.MoveNext())
            {
                if (MyEnum.Current is Part)
                {
                    var part = (Part)MyEnum.Current;

                    myList.Add(part);
                }
                pgrbarParts.PerformStep();
            }

            pgrbarParts.Visible = false;
            return myList;
        }

        private List<Part> getSelectedParts()
        {
            if (MyModel.GetConnectionStatus())
            {
                var MyEnum = new Tekla.Structures.Model.UI.ModelObjectSelector().GetSelectedObjects();
                return TeklaEnumToPartList(MyEnum);
            }
            else
            {
                MessageBox.Show("Can't connect to Model.");
                logger.WriteLog("Não foi possível conectar ao modelo!");
                return null;
            }
        }

        private List<Part> getAllParts()
        {
            var myList = new List<string>();
            if (MyModel.GetConnectionStatus())
            {
                var objType = new ObjectFilterExpressions.Type();
                var type = new NumericConstantFilterExpression(Tekla.Structures.TeklaStructuresDatabaseTypeEnum.PART);

                var expression = new BinaryFilterExpression(objType, NumericOperatorType.IS_EQUAL, type);

                var filterCollection = new BinaryFilterExpressionCollection
                {
                    new BinaryFilterExpressionItem(expression)
                };

                ModelObjectEnumerator.AutoFetch = true;
                var myEnum = MyModel.GetModelObjectSelector().GetObjectsByFilter(filterCollection);


                return TeklaEnumToPartList(myEnum);
            }
            else
            {
                MessageBox.Show("Can't connect to Model.");
                logger.WriteLog("Não foi possível conectar ao modelo!");
                return null;
            }
        }

        int ano = 2024;
        int mes = 12;
        int dia = 31;



        private void btnUpadate_Click(object sender, EventArgs e)
        {
            DateTime dateexp = new DateTime(ano, mes, dia, 17, 00, 0); //condição de data (ano , mês, dia, hora, minuto)


            if (dateexp >= DateTime.Now) // condição de data
            {
                var change = false;


                var boltGroups = new List<BoltGroup>();
                if (rdAllParts.Checked)
                    boltGroups = getAllBolts();
                else
                    boltGroups = getSelectedBolts();


                var partGroups = new List<Part>();
                if (rdAllParts.Checked)
                    partGroups = getAllParts();
                else
                    partGroups = getSelectedParts();


                var excelFile = new List<TSMA_Excel.ExcelLine>();
                if (boltGroups.Count > 0 || partGroups.Count > 0)
                    excelFile = new TSMA_Excel("Planilha1", pgrbarParts).ExcelLines;


                #region Bolts
                if (boltGroups.Count > 0)
                {
                    pgrbarParts.Value = 0;
                    pgrbarParts.Maximum = boltGroups.Count;

                    foreach (var bolt in boltGroups)
                    {
                        string boltName = string.Empty;
                        string washerName = string.Empty;
                        string washerName2 = string.Empty; // alterado
                        string washerName3 = string.Empty; // alterado
                        string nutName = string.Empty;
                        string nutName2 = string.Empty; // alterado
                        string namepart = string.Empty;

                        bolt.GetReportProperty("NAME", ref boltName);
                        bolt.GetReportProperty("WASHER.NAME1", ref washerName);
                        bolt.GetReportProperty("WASHER.NAME2", ref washerName2); // alterado
                        bolt.GetReportProperty("WASHER.NAME3", ref washerName3); // alterado
                        bolt.GetReportProperty("NUT.NAME1", ref nutName);
                        bolt.GetReportProperty("NUT.NAME2", ref nutName2); // alterado




                        var excelLine = excelFile.Where(b => b.description == boltName).FirstOrDefault();


                        if (excelLine != null)
                        {
                            if (!bolt.Bolt)
                            {
                                change = true;
                                bolt.SetUserProperty(txtBoltMark.Text, "Não Utilizado");
                                bolt.SetUserProperty(txtBoltCode.Text, "Não Utilizado");
                                logger.WriteLog("inserção de Não Utilizado nos parafusos!");
                                //bolt.Modify();
                            }

                            else
                            {

                                change = true;

                                bolt.SetUserProperty(txtBoltMark.Text, excelLine.mark);
                                bolt.SetUserProperty(txtBoltCode.Text, excelLine.codeERP);
                                //bolt.Modify();
                            }
                        }

                        excelLine = excelFile.Where(b => b.description == washerName).FirstOrDefault();
                        if (excelLine != null)
                        {
                            if (!bolt.Washer1)
                            {
                                change = true;
                                bolt.SetUserProperty(txtWasherMark.Text, "Não Utilizado");
                                bolt.SetUserProperty(txtWasherCode.Text, "Não Utilizado");
                                logger.WriteLog("inserção de Não Utilizado nas Porcas!");
                                //bolt.Modify();
                            }


                            else
                            {

                                change = true;

                                bolt.SetUserProperty(txtWasherMark.Text, excelLine.mark);
                                bolt.SetUserProperty(txtWasherCode.Text, excelLine.codeERP);
                                //bolt.Modify();
                            }
                        }

                        excelLine = excelFile.Where(b => b.description == washerName2).FirstOrDefault();
                        if (excelLine != null)
                        {
                            if (!bolt.Washer2)
                            {
                                change = true;
                                bolt.SetUserProperty(txtWasherMark2.Text, "Não Utilizado");
                                bolt.SetUserProperty(txtWasherCode2.Text, "Não Utilizado");
                                logger.WriteLog("inserção de Não Utilizado nas Porcas 2!");
                                //bolt.Modify();
                            }


                            else
                            {

                                change = true;

                                bolt.SetUserProperty(txtWasherMark2.Text, excelLine.mark);
                                bolt.SetUserProperty(txtWasherCode2.Text, excelLine.codeERP);
                                //bolt.Modify();
                            }
                        }

                        excelLine = excelFile.Where(b => b.description == washerName3).FirstOrDefault();
                        if (excelLine != null)
                        {
                            if (!bolt.Washer3)
                            {
                                change = true;
                                bolt.SetUserProperty(txtWasherMark3.Text, "Não Utilizado");
                                bolt.SetUserProperty(txtWasherCode3.Text, "Não Utilizado");
                                logger.WriteLog("inserção de Não Utilizado nas Porcas 3!");
                                //bolt.Modify();
                            }

                            else
                            {

                                change = true;

                                bolt.SetUserProperty(txtWasherMark3.Text, excelLine.mark);
                                bolt.SetUserProperty(txtWasherCode3.Text, excelLine.codeERP);
                                //bolt.Modify();
                            }
                        }

                        excelLine = excelFile.Where(b => b.description == nutName2).FirstOrDefault();
                        if (excelLine != null)
                        {

                            if (!bolt.Nut2)
                            {
                                change = true;
                                bolt.SetUserProperty(txtNutMark2.Text, "Não Utilizado");
                                bolt.SetUserProperty(txtNutCode2.Text, "Não Utilizado");
                                logger.WriteLog("inserção de Não Utilizado nas Arruelas!");
                                // bolt.Modify();
                            }


                            else
                            {

                                change = true;

                                bolt.SetUserProperty(txtNutMark2.Text, excelLine.mark);
                                bolt.SetUserProperty(txtNutCode2.Text, excelLine.codeERP);
                                // bolt.Modify();
                            }

                        }

                        excelLine = excelFile.Where(b => b.description == nutName).FirstOrDefault();
                        if (excelLine != null)
                        {
                            if (!bolt.Nut1)
                            {
                                change = true;
                                bolt.SetUserProperty(txtNutMark.Text, "Não Utilizado");
                                bolt.SetUserProperty(txtNutCode.Text, "Não Utilizado");
                                logger.WriteLog("inserção de Não Utilizado nas Arruelas 2!");
                                //bolt.Modify();
                            }


                            else
                            {

                                change = true;

                                bolt.SetUserProperty(txtNutMark.Text, excelLine.mark);
                                bolt.SetUserProperty(txtNutCode.Text, excelLine.codeERP);
                                //bolt.Modify();
                            }

                        }

                        pgrbarParts.PerformStep();
                    }
                }
                #endregion



                #region Parts 
                if (partGroups.Count > 0)
                {
                    pgrbarParts.Value = 0;
                    pgrbarParts.Maximum = partGroups.Count;

                    foreach (var part in partGroups)
                    {
                        var partProfile = part.Profile.ProfileString;




                        var excelLine = excelFile.Where(b => b.description == partProfile).FirstOrDefault();
                        if (excelLine != null)
                        {
                            if (partProfile.ToUpper().Contains("PARAF"))
                            {
                                change = true;

                                part.SetUserProperty(txtBoltMark.Text, excelLine.mark);
                                part.SetUserProperty(txtBoltCode.Text, excelLine.codeERP);

                                part.SetUserProperty(txtWasherMark.Text, " ");
                                part.SetUserProperty(txtWasherCode.Text, " ");

                                part.SetUserProperty(txtNutMark.Text, " ");
                                part.SetUserProperty(txtNutCode.Text, " ");

                                //part.Modify();


                            }

                            if (partProfile.ToUpper().Contains("ARRUELA"))
                            {
                                change = true;

                                part.SetUserProperty(txtWasherMark.Text, excelLine.mark);
                                part.SetUserProperty(txtWasherCode.Text, excelLine.codeERP);

                                part.SetUserProperty(txtNutMark.Text, " ");
                                part.SetUserProperty(txtNutCode.Text, " ");

                                part.SetUserProperty(txtBoltMark.Text, " ");
                                part.SetUserProperty(txtBoltCode.Text, " ");

                                // part.Modify();
                            }

                            if (partProfile.ToUpper().Contains("PORCA"))
                            {
                                change = true;

                                part.SetUserProperty(txtNutMark.Text, excelLine.mark);
                                part.SetUserProperty(txtNutCode.Text, excelLine.codeERP);

                                part.SetUserProperty(txtBoltMark.Text, " ");
                                part.SetUserProperty(txtBoltCode.Text, " ");

                                part.SetUserProperty(txtWasherMark.Text, " ");
                                part.SetUserProperty(txtWasherCode.Text, " ");


                                //part.Modify();



                            }
                        }
                        pgrbarParts.PerformStep();
                    }
                }
                #endregion 

                if (change)
                {
                    MyModel.CommitChanges();
                    MessageBox.Show(String.Format("Atributos Inseridos {0} {0} Data de Expiração {1}", Environment.NewLine, dateexp), "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    logger.WriteLog("Atributos Inseridos!");
                }
                else
                {
                    MessageBox.Show(String.Format("Nada alterado {0} {0} Data de Expiração {1}", Environment.NewLine, dateexp), "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    logger.WriteLog("Nada alterado!");
                }


            }

            else
            {
                MessageBox.Show("Data Expirada!!!!", "Data Expiração", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                logger.WriteLog("Nada alterado!");
            }
        }


        /*
        private List<string> CheckAndDeleteFiles(string path, List<string> names, FileInfo[] availableFiles)
        {
            var log = new StringBuilder();
            var existingFiles = new List<string>();

            foreach (var file in availableFiles)
            {
                var fName = Path.GetFileNameWithoutExtension(file.FullName);

                if (names.Contains(fName))
                {
                    existingFiles.Add(fName);
                }
                else
                {
                    var dest = string.Format("{0}\\{1}", path, file.Name);
                    if (!new FileInfo(dest).Exists)
                        file.MoveTo(dest);
                    else
                    {
                        log.AppendLine(String.Format("Arquivo deletado: {0}", file.Name));
                        file.Delete();
                    }
                }
            }

            if (log.Length > 0)
                MessageBox.Show(log.ToString());

            return existingFiles;
        }

        private void CreateFiles(string path, List<string> names, FileInfo[] availableFiles, List<string> exiting)
        {
            var log = new StringBuilder();

            foreach (var comment in names)
            {
                if (exiting.Contains(comment))
                    continue;

                var file = availableFiles.Where(n => Path.GetFileNameWithoutExtension(n.FullName) == comment).FirstOrDefault();

                if (file != null)
                {
                    var dest = string.Format("{0}\\{1}", path, file.Name);
                    file.MoveTo(dest);

                }
                else
                {
                    log.AppendLine(String.Format("Não foi encontrado desenho com o nome: {0}", comment));

                }
            } 

            if (log.Length > 0)
                MessageBox.Show(log.ToString()); 

        }

        public static string GetModelPath()
        {
            try
            {
                var modelPath = string.Empty;

                //Set up model connection w/TS
                Model MyModel = new Model();
                if (MyModel.GetConnectionStatus() &&
                    MyModel.GetInfo().ModelPath != string.Empty)
                {
                    return MyModel.GetInfo().ModelPath;
                }
                else
                {
                    //If no connection to model is possible show error message
                    MessageBox.Show("Tekla Structures not open or model not open.",
                        "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }
            }  //end of try loop
            catch { return string.Empty; }

        } */

        private void txtWasherMark_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoltMark_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dateexp = new DateTime(ano, mes, dia, 17, 00, 0); //condição de data (ano , mês, dia, hora, minuto)


            if (dateexp >= DateTime.Now) // condição de data
            {
                var change = false;


                var boltGroups = new List<BoltGroup>();
                if (rdAllParts.Checked)
                    boltGroups = getAllBolts();
                else
                    boltGroups = getSelectedBolts();


                var partGroups = new List<Part>();
                if (rdAllParts.Checked)
                    partGroups = getAllParts();
                else
                    partGroups = getSelectedParts();


                var excelFile = new List<TSMA_Excel.ExcelLine>();
                if (boltGroups.Count > 0 || partGroups.Count > 0)
                    excelFile = new TSMA_Excel("Planilha1", pgrbarParts).ExcelLines;


                #region Bolts
                if (boltGroups.Count > 0)
                {
                    pgrbarParts.Value = 0;
                    pgrbarParts.Maximum = boltGroups.Count;

                    foreach (var bolt in boltGroups)
                    {
                        string boltName = string.Empty;
                        string washerName = string.Empty;
                        string washerName2 = string.Empty; // alterado
                        string washerName3 = string.Empty; // alterado
                        string nutName = string.Empty;
                        string nutName2 = string.Empty; // alterado
                        string namepart = string.Empty;
                        
                        bolt.GetReportProperty("NAME", ref boltName);
                        bolt.GetReportProperty("WASHER.NAME1", ref washerName);
                        bolt.GetReportProperty("WASHER.NAME2", ref washerName2); // alterado
                        bolt.GetReportProperty("WASHER.NAME3", ref washerName3); // alterado
                        bolt.GetReportProperty("NUT.NAME1", ref nutName);
                        bolt.GetReportProperty("NUT.NAME2", ref nutName2); // alterado
                        



                        var excelLine = excelFile.Where(b => b.description == boltName).FirstOrDefault();


                        if (excelLine != null)
                        {
                            change = true;

                            bolt.SetUserProperty(txtBoltMark.Text, "Limpo");
                            bolt.SetUserProperty(txtBoltCode.Text, "Limpo");
                            //bolt.Modify();
                        }

                        excelLine = excelFile.Where(b => b.description == washerName).FirstOrDefault();
                        if (excelLine != null)
                        {
                            change = true;

                            bolt.SetUserProperty(txtWasherMark.Text, "Limpo");
                            bolt.SetUserProperty(txtWasherCode.Text, "Limpo");
                            //bolt.Modify();
                        }

                        excelLine = excelFile.Where(b => b.description == washerName2).FirstOrDefault();
                        if (excelLine != null)
                        {
                            change = true;

                            bolt.SetUserProperty(txtWasherMark2.Text, "Limpo");
                            bolt.SetUserProperty(txtWasherCode2.Text, "Limpo");
                           // bolt.Modify();
                        }

                        excelLine = excelFile.Where(b => b.description == washerName3).FirstOrDefault();
                        if (excelLine != null)
                        {
                            change = true;

                            bolt.SetUserProperty(txtWasherMark3.Text, "Limpo");
                            bolt.SetUserProperty(txtWasherCode3.Text, "Limpo");
                            //bolt.Modify();
                        }

                        excelLine = excelFile.Where(b => b.description == nutName2).FirstOrDefault();
                        if (excelLine != null)
                        {
                            change = true;

                            bolt.SetUserProperty(txtNutMark2.Text, "Limpo");
                            bolt.SetUserProperty(txtNutCode2.Text, "Limpo");
                           // bolt.Modify();
                        }

                        excelLine = excelFile.Where(b => b.description == nutName).FirstOrDefault();
                        if (excelLine != null)
                        {
                            change = true;

                            bolt.SetUserProperty(txtNutMark.Text, "Limpo");
                            bolt.SetUserProperty(txtNutCode.Text, "Limpo");
                            //bolt.Modify();
                        }

                        pgrbarParts.PerformStep();
                    }
                }
                #endregion



                #region Parts
                if (partGroups.Count > 0)
                {
                    pgrbarParts.Value = 0;
                    pgrbarParts.Maximum = partGroups.Count;

                    foreach (var part in partGroups)
                    {
                        var partProfile = part.Profile.ProfileString;




                        var excelLine = excelFile.Where(b => b.description == partProfile).FirstOrDefault();
                        if (excelLine != null)
                        {
                            if (partProfile.ToUpper().Contains("PARAF"))
                            {
                                change = true;

                                part.SetUserProperty(txtBoltMark.Text, "Limpo");
                                part.SetUserProperty(txtBoltCode.Text, "Limpo");

                                part.SetUserProperty(txtWasherMark.Text, "Limpo");
                                part.SetUserProperty(txtWasherCode.Text, "Limpo");

                                part.SetUserProperty(txtNutMark.Text, "Limpo");
                                part.SetUserProperty(txtNutCode.Text, "Limpo");

                               // part.Modify();
                            }

                            if (partProfile.ToUpper().Contains("ARRUELA"))
                            {
                                change = true;

                                part.SetUserProperty(txtWasherMark.Text, "Limpo");
                                part.SetUserProperty(txtWasherCode.Text, "Limpo");

                                part.SetUserProperty(txtNutMark.Text, "Limpo");
                                part.SetUserProperty(txtNutCode.Text, "Limpo");

                                part.SetUserProperty(txtBoltMark.Text, "Limpo");
                                part.SetUserProperty(txtBoltCode.Text, "Limpo");

                                //part.Modify();
                            }

                            if (partProfile.ToUpper().Contains("PORCA"))
                            {
                                change = true;

                                part.SetUserProperty(txtNutMark.Text, "Limpo");
                                part.SetUserProperty(txtNutCode.Text, "Limpo");

                                part.SetUserProperty(txtBoltMark.Text, "Limpo");
                                part.SetUserProperty(txtBoltCode.Text, "Limpo");

                                part.SetUserProperty(txtWasherMark.Text, "Limpo");
                                part.SetUserProperty(txtWasherCode.Text, "Limpo");

                                //part.Modify();
                            }
                        }
                        pgrbarParts.PerformStep();
                    }
                }
                #endregion

                if (change)
                {
                    MyModel.CommitChanges();
                    MessageBox.Show(String.Format("Atributos Limpos {0} {0} Data de Expiração {1}", Environment.NewLine, dateexp), "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                    MessageBox.Show(String.Format("Nada alterado {0} {0} Data de Expiração {1}", Environment.NewLine, dateexp), "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Warning);



            }
            else
                MessageBox.Show("Data Expirada!!!!", "Data Expiração", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void txtBoltCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
    }

