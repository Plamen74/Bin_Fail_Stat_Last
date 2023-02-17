using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using System.Linq;


namespace WindowsApplication8
{
    public partial class Form1 : Form
    {
        //string[] positionTextBoxBackUp = new string[200];//back up for textBox5(position box)
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        #region define variables
        SortedDictionary<int, string> namesAndPositionOfMeasuredBinsWithLimits = new SortedDictionary<int, string>();
        SortedDictionary<int, double> valueAndPositionOfLowLimits = new SortedDictionary<int, double>();
        SortedDictionary<int, double> valueAndPositionOfHiLimits = new SortedDictionary<int, double>();
        SortedDictionary<int, double> valueAndPositionOfMin = new SortedDictionary<int, double>();//store position(bin) and value(double) of min failed value
        SortedDictionary<int, double> valueAndPositionOfMax = new SortedDictionary<int, double>();//store position(bin) and value(double) of max failed value
        SortedDictionary<int, string> numberOfFailsMin = new SortedDictionary<int, string>();
        SortedDictionary<int, string> numberOfFailsMax = new SortedDictionary<int, string>();
        Dictionary<int, string> ledRefBins = new Dictionary<int, string>();
        List<string> allLinesOfTextWithHeader = new List<string>();//equals to number of module tested
        List<string> allLinesOfText = new List<string>();//equals to number of module tested
        List<string> allElementsOfText = new List<string>();
        List<string> nameOfBins = new List<string>();
        List<int> binOfFail = new List<int>();
        List<int> selectedBins = new List<int>();
        List<string> checkedBinsBox = new List<string>();
        List<string> HiLimit = new List<string>();//keep hi limit
        List<string> LoLimit = new List<string>();//keep low limit
        List<string> valuesList = new List<string>();
        List<string> lineOfLogList = new List<string>();
        List<int> positionsOfLowLimits = new List<int>();//Bin1,Bin3,(1,3...
        List<int> positionsOfHiLimits = new List<int>();//Bin1,Bin3,(1,3...
        List<int> positionsWithoutLimits = new List<int>();//Bin1,Bin3,(1,3...
        string[] names;
        string binNameLine;
        string fullDirPath;
        double value = 0.0;
        double minV = 0.0;
        double maxV = 0.0;
        int offsetBint = 0;
        string dirPathDest;
        List<string> allBinsMin = new List<string>();//List where dictionary is converted for easier displaying
        List<string> allBinsMax = new List<string>();//List where dictionary is converted for easier displaying
        List<string> numberOfFailedBins = new List<string>();//List where dictionary is converted for easier displaying
        #endregion
        double rLowLimitLeakageTest = 0.0;

        /// <summary>
        /// Get names of Bins
        /// </summary>
        /// <param name="offset"></param>
        public void GetNamesOfBins(int offset)
        {
            binNameLine = allLinesOfText[0];//string for Bin Names

            names = binNameLine.Split(';', ',', '\t').Skip(offsetBint).ToArray();
            nameOfBins = names.ToList();//name of bins in list
            for (int i = 0; i < names.Length; i++)
            {
                if (!((names[i].Contains("LOW")) || (names[i].Contains("LO")) || (names[i].Contains("Lo")) || (names[i].Contains("MIN"))
                    || (names[i].Contains("MAX")) || (names[i].Contains("HI")) || (names[i].Contains("Hi"))))
                {//BINs without Lo and Hi limits 
                    //namesAndPositionOfMeasuredBinsWithLimits.Add(i,names[i]);
                    positionsWithoutLimits.Add(i);
                }
                else if ((names[i].Contains("LOW")) || (names[i].Contains("LO")) || (names[i].Contains("Lo")) || (names[i].Contains("MIN")))
                {//Low,bin,Hi-1,2,3...
                    positionsOfLowLimits.Add(i);//2
                }
                else if ((names[i].Contains("MAX")) || (names[i].Contains("HI")) || (names[i].Contains("Hi")))
                {//Low,bin,Hi-1,2,3...
                    positionsOfHiLimits.Add(i);//2
                }
            }
            for (int i = 0; i < names.Length; i++)
            {
                if (positionsOfLowLimits.Contains(i))
                {
                    if (positionsWithoutLimits.Contains(i + 1))
                    {
                        positionsWithoutLimits.Remove(i + 1);
                    }
                }
            }
        }

        /// <summary>
        /// Button start  click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            //Check entered R
            if (!double.TryParse(r_limit_tb.Text.ToString(), out rLowLimitLeakageTest))
            {
                MessageBox.Show("Enter valid value for R Low Leakage test > 0", "eror", MessageBoxButtons.OK);
                r_limit_tb.Text = "";
                button3_Click(this, e);
                return;
            }
            else if (rLowLimitLeakageTest <= 0)
            {
                MessageBox.Show("Enter valid valuefor R Low Leakage test > 0", "eror", MessageBoxButtons.OK);
                r_limit_tb.Text = "";
                button3_Click(this, e);
                return;
            }
            //********
            //Check entered offset
            if (!int.TryParse(offset_tb.Text.ToString(), out offsetBint))
            {
                MessageBox.Show("Enter valid offset value(positive number)", "error");
                offset_tb.Text = "";
                button3_Click(this, e);
                return;
            }
            else if (offsetBint < 0)
            {
                MessageBox.Show("Enter valid offset value(positive number)", "error");
                offset_tb.Text = "";
                button3_Click(this, e);
                return;
            }
            //****************
            //Check if log file is located
            if(fullDirPath == null)
            {
                MessageBox.Show("First Have To OPEN Log File", "Error", MessageBoxButtons.OK);
                return;
            }
            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader(fullDirPath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    allLinesOfText.Add(line); // Add to list.
                }
                GetNamesOfBins(offsetBint);//extract names of bins
                for (int n = 1; n < allLinesOfText.Count; n++)//without first line-name of bins
                {
                    string[] words = allLinesOfText[n].Split(';', ',', '\t')
                        .Skip(offsetBint).ToArray();
                    foreach (string word in words)
                    {
                        allElementsOfText.Add(word);
                    }
                }
            }
            for (int i = 0; i < names.Count(); i++)//exlude first offsetbint elements
            {
                bins_clb.Items.Insert(i, names[i]);
            }
           
            numoftestedparts_tb.Text = (allLinesOfText.Count - 1).ToString(); // Show nUmber of tested modules in textbox
            status_tb.Text = "Processing";
            status_tb.BackColor = Color.Yellow;


            Thread tr1 = new Thread(CheckForFailedBin);
            tr1.Start();
            tr1.Join();

            //CheckForFailedBin();
            PrintSavedFailValues();
            //fil Low and Hi limits windows
            foreach (var value in valueAndPositionOfLowLimits.Values)
            {
                LoLimit.Add(value.ToString());
            }
            foreach (var value in valueAndPositionOfHiLimits.Values)
            {
                HiLimit.Add(value.ToString());
            }
            lowlimit_lb.DataSource = new BindingSource(LoLimit, null);//prints low limits in <LO LIM> window
            hilimit_lb.DataSource = new BindingSource(HiLimit, null);//prints hi limits in <HI LIM> window
            status_tb.Text = "Done";
            status_tb.BackColor = Color.LimeGreen;
        }

        /// <summary>
        /// check for Fail and calculate position
        /// </summary>
        void CheckForFailedBin()
        {
            int numOfFailedBins = 0;
            string[] lineOfLog;
            string[] oneLineOfLog;
            for (int n = 1; n < allLinesOfText.Count; n++)
            {
                #region get values from lines > 1
                if (n > 1)//line > 1
                {
                    //valuesList.Clear();
                    oneLineOfLog = allLinesOfText[n].Split(';','\t').Skip(offsetBint).ToArray();
                    lineOfLogList = oneLineOfLog.ToList();
                    if (lineOfLogList.Count < names.Length)//if line breaks before the end- add line with ';'
                    {
                        for (int i = 0; i < (names.Length - oneLineOfLog.Length); i++)
                        {
                            lineOfLogList.Add(";");
                        }
                    }
                    else { }
                    lineOfLog = lineOfLogList.ToArray();
                    //***********get  values(not limits) from next lines
                    for (int k = 0; k < names.Count(); k++)// k - number of column in logfile 
                    {
                        if (lineOfLog[k] != "")//removes empty elements (k-1)
                        {
                            //******* convert to double
                            try
                            {
                                value = Convert.ToDouble(lineOfLog[k]);// convert to double [k]
                                if (value > 10000000.0)
                                {
                                    value = 10000000.0;
                                }
                            }
                            catch
                            {
                                value = 100000000.0;//if value is not a number
                            }
                            //case with limits
                            if ((positionsOfLowLimits.Contains(k - 1)) && (positionsOfHiLimits.Contains(k + 1)))
                            {
                                //check according to low limit
                                //value is lower than low limit and count this bin for first time
                                if ((value < valueAndPositionOfLowLimits[k - 1]) && (!valueAndPositionOfMin.ContainsKey(k)))//k-1
                                {
                                    try
                                    {
                                        if (!valueAndPositionOfMin[k].Equals(value))//if No Record in this Key with same value
                                        {
                                            valueAndPositionOfMin.Add((k), value);
                                            numberOfFailsMin.Add((k), "1");//count this bin for first time
                                        }
                                        else { }
                                    }
                                    catch
                                    {
                                        valueAndPositionOfMin.Add((k), value);
                                        numberOfFailsMin.Add((k), "1");//count this bin for first time
                                    }
                                }
                                else if ((value < valueAndPositionOfLowLimits[k - 1]) && (valueAndPositionOfMin.ContainsKey(k)))//k-1
                                //if there is a record for this bin,and check if new value is < than recorded in order to replace it
                                {
                                    binOfFail.Add(k);
                                    if (value != 100000000.0)
                                    {
                                        if (value < minV)
                                            minV = value;
                                        else if (value > maxV)
                                            maxV = value;
                                        numOfFailedBins = Convert.ToInt32(numberOfFailsMin[k]) + 1;//k-1
                                        numberOfFailsMin.Remove(k);
                                        numberOfFailsMin.Add(k, numOfFailedBins.ToString());//increase number of this bin with 1 for min value
                                        if (valueAndPositionOfMin[k] > value)//if new value is < then min recorded-> record new value
                                        {
                                            valueAndPositionOfMin.Remove(k);
                                            valueAndPositionOfMin.Add((k), value);
                                        }
                                    }
                                }
                                //check acording to hi limit
                                //if writes for first time in dict
                                else if ((value > valueAndPositionOfHiLimits[k + 1]) && (!valueAndPositionOfMax.ContainsKey(k)))//k+1
                                {

                                    try
                                    {
                                        if (!valueAndPositionOfMax[k].Equals(value))//if No Record in this Key with same value
                                        {
                                            valueAndPositionOfMax.Add((k), value);
                                            numberOfFailsMax.Add((k), "1");//count this bin for first time /format is -> (minnumber,maxnumber) e.g(-,1) or (1,1)
                                        }
                                        else { }
                                    }
                                    catch
                                    {
                                        valueAndPositionOfMax.Add((k), value);
                                        numberOfFailsMax.Add((k), "1");//count this bin for first time /format is -> (minnumber,maxnumber) e.g(-,1) or (1,1)
                                    }


                                }
                                //if there is record for this bin yet,and check if new value is > than recorded in order to replace it
                                else if ((value > valueAndPositionOfHiLimits[k + 1]) && (valueAndPositionOfMax.ContainsKey(k)))//k+1
                                {
                                    numOfFailedBins = Convert.ToInt32(numberOfFailsMax[k]) + 1;//increase number of failed parts for this bin
                                    numberOfFailsMax.Remove(k);//erase record and then add new increased value
                                    numberOfFailsMax.Add((k), numOfFailedBins.ToString());//increase number of this bin with 1
                                    if (valueAndPositionOfMax[k] < value)//if new value is > then max recorded value -> record new value - k-1
                                    {
                                        valueAndPositionOfMax.Remove(k);
                                        valueAndPositionOfMax.Add((k), value);
                                    }
                                }

                            }
                        }
                    }
                }
                #endregion
                #region get limits from second line
                else if (n == 1)
                {
                    valuesList.Clear();//string list with all values in line without ';'
                    valuesList = allLinesOfText[n].Split(';', ',', '\t').Skip(offsetBint).ToList();//second line of text without ';' (limits)
                    if (valuesList.Count < names.Length)//if line breaks before the end- add line with ';'
                    {
                        for (int i = 0; i < (names.Length - valuesList.Count); i++)
                        {
                            valuesList.Add(";");
                        }
                    }
                    else { }
                    for (int k = 0; k < names.Count(); k++)// k - number of column in logfile 
                    {
                        if (valuesList[k] != "")//removes empty elements (k-1)
                        {
                            //******* convert to double
                            try
                            {
                                value = Convert.ToDouble(valuesList[k]);// convert to double [k]
                                if (value > 10000000.0)
                                {
                                    value = 10000000.0;
                                }
                            }
                            catch
                            {
                                value = 100000000.0;//if value is not a number
                            }
                            //** check if item is low limit (not value,not max limit)
                            if (positionsOfLowLimits.Contains(k))//record for low limit is before 'k'
                            {//fill dict with position and value of low limit
                                valueAndPositionOfLowLimits.Add(k, value);
                            }
                            if (positionsOfHiLimits.Contains(k))
                            {//fill dict with position and value of hi limit
                                valueAndPositionOfHiLimits.Add(k, value);//hilimit,value,
                            }
                            //else if ((valueAndPositionOfLowLimits.ContainsKey(k)) && (!positionsOfHiLimits.Contains(k)))
                            else if (positionsWithoutLimits.Contains(k))
                            {
                                //positionsWithoutLimits.Add(k);
                                valueAndPositionOfLowLimits.Add(k, rLowLimitLeakageTest);
                                valueAndPositionOfHiLimits.Add(k, 10000001.0);
                            }
                        }
                    }
                }//end of gets limits 
                #endregion
            }
        }
        /// <summary>
        /// Print minFail and maxFAIL values and number of failed min and max values
        /// </summary>
        void PrintSavedFailValues()
        {
            //procces <FAIL MIN> and <FAIL MAX> windows
            for (int i = 0; i < nameOfBins.Count; i++)
            {
                //MIN values
                //if there is min and max value in position i in dict's for min and max{min,max}
                if ((valueAndPositionOfMin.ContainsKey(i)) && (valueAndPositionOfMax.ContainsKey(i)))
                {
                    allBinsMin.Add(valueAndPositionOfMin[i].ToString());//show min value for saved bin
                    allBinsMax.Add(valueAndPositionOfMax[i].ToString());//show max value for saved bin
                    //show number of fails for this bin in format(minvalue,maxvalue)
                    numberOfFailedBins.Add(numberOfFailsMin[i] + "  ,  " + numberOfFailsMax[i]);
                }
                //if there is min and no max value in position i in dict's for min and max{min,-}
                else if ((valueAndPositionOfMin.ContainsKey(i)) && (!valueAndPositionOfMax.ContainsKey(i)))
                {
                    allBinsMin.Add(valueAndPositionOfMin[i].ToString());//show min value for this bin
                    allBinsMax.Add(" - ");
                    numberOfFailedBins.Add(numberOfFailsMin[i] + "  , - ");//show number of min value  and "-" for max num for this bin
                }
                //if there is no min value and max value in position i in dict's for min and max{-,max}
                else if ((!valueAndPositionOfMin.ContainsKey(i)) && (valueAndPositionOfMax.ContainsKey(i)))
                {
                    allBinsMin.Add(" - ");
                    allBinsMax.Add(valueAndPositionOfMax[i].ToString());//show max value for this bin
                    numberOfFailedBins.Add(" - , " + numberOfFailsMax[i]);//show"-" for of min value  and max value for max num for this bin
                }
                //if there is no min value and no  max value in position i in dict's for min and max{-,-}
                else if ((!valueAndPositionOfMin.ContainsKey(i)) && (!valueAndPositionOfMax.ContainsKey(i)))
                {
                    allBinsMin.Add(" - ");
                    allBinsMax.Add(" - ");
                    numberOfFailedBins.Add(" - , - ");//show"-" for of min value  and max value for max num for this bin
                }
                else
                {
                    //unpredictable case
                }
            }
            listBox1.DataSource = new BindingSource(allBinsMin, null);//prints Min values in Fail Min window
            listBox2.DataSource = new BindingSource(allBinsMax, null);//prints Max values in Fail Max window
            numoffails_lb.DataSource = new BindingSource(numberOfFailedBins, null);//prints number of failed bins
        }
        /// <summary>
        /// Button clear 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            listBox2.DataSource = null;
            numoffails_lb.DataSource = null;
            lowlimit_lb.DataSource = null;
            hilimit_lb.DataSource = null;
            bins_clb.Items.Clear();
            bins_clb.Update();
            allLinesOfText.Clear();
            valueAndPositionOfMin.Clear();
            valueAndPositionOfMax.Clear();
            numberOfFailsMin.Clear();
            numberOfFailsMax.Clear();
            allElementsOfText.Clear();
            nameOfBins.Clear();
            binOfFail.Clear();
            selectedBins.Clear();
            checkedBinsBox.Clear();
            HiLimit.Clear();
            LoLimit.Clear();
            numberOfFailedBins.Clear();
            valueAndPositionOfLowLimits.Clear();
            valueAndPositionOfHiLimits.Clear();
            status_tb.Text = "";
            status_tb.BackColor = DefaultBackColor;
            numoftestedparts_tb.Text = "";
        }

        /// <summary>
        /// Exit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// select bin from BINs window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int k = 0; k < nameOfBins.Count - offsetBint; k++)//Enter selected item in list selectedBins<>
            {

                if (bins_clb.GetItemChecked(k))
                {
                    if (selectedBins.Contains(k))
                    {
                    }
                    else
                    {
                        selectedBins.Add(k);//add index of checked item in List
                    }
                }
            }
            if (selectedBins.Count == bins_clb.CheckedIndices.Count)//checked items are equals to items in List selectedBins<>
            {
                if (bins_clb.CheckedItems.Count != 0)//if there are selected items - prints them
                {
                    for (int x = 0; x < bins_clb.CheckedItems.Count; x++)
                    {
                        listBox1.SetSelected(bins_clb.CheckedIndices[x], true);
                        listBox2.SetSelected(bins_clb.CheckedIndices[x], true);
                        numoffails_lb.SetSelected(bins_clb.CheckedIndices[x], true);
                        lowlimit_lb.SetSelected(bins_clb.CheckedIndices[x], true);
                        hilimit_lb.SetSelected(bins_clb.CheckedIndices[x], true);
                    }
                }
            }
            else//if selected items on display are not equal to entered in list before(there is erased item)
            {
                foreach (int item in selectedBins)
                {
                    if (bins_clb.CheckedIndices.Contains(item))
                    {
                    }
                    else
                    {
                        selectedBins.Remove(item);//remove rechecked item
                        break;
                    }
                }
            }
            bins_clb.ClearSelected();
            listBox1.ClearSelected();
            listBox2.ClearSelected();
            numoffails_lb.ClearSelected();
            lowlimit_lb.ClearSelected();
            hilimit_lb.ClearSelected();

            //show refreshed state for checked items
            for (int x = 0; x < selectedBins.Count; x++)
            {
                listBox1.SetSelected(bins_clb.CheckedIndices[x], true);
                listBox2.SetSelected(bins_clb.CheckedIndices[x], true);
                numoffails_lb.SetSelected(bins_clb.CheckedIndices[x], true);
                lowlimit_lb.SetSelected(bins_clb.CheckedIndices[x], true);
                hilimit_lb.SetSelected(bins_clb.CheckedIndices[x], true);
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// Click Browse for single log file Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                fullDirPath = ofd.FileName;
            }
        }

        /// <summary>


  

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}