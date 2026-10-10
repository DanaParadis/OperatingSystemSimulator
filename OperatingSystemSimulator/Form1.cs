using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OperatingSystemSimulator
{
    public partial class Form1 : Form
    {
        private OS osSimulator;
        public Form1()
        {
            InitializeComponent();
            osSimulator = new OS(1, 4, 50);
        }
        private void btnClockTick_Click(object sender, EventArgs e)
        {

            osSimulator.clockTick();
            updateInterface();
            showProcess();

            


        }
        private void updateInterface()
        {
            updateNew();
            updateReady();
            updateBlocked();
            updateFinished();


        }

        private void updateNew()
        {
            dtgNew.Rows.Clear();

            foreach (Process p in osSimulator.listNew)
            {

                dtgNew.Rows.Add(
                    p.PID,
                    p.size,
                    p.programCounter
                    );
            }
        }
        private void updateReady()
        {
            dtgReady.Rows.Clear();

            foreach (Process p in osSimulator.listReady)
            {

                dtgReady.Rows.Add(
                    p.PID,
                    p.size,
                    p.programCounter,
                    p.priority
                    );
            }
        }
        private void updateBlocked()
        {
            dtgBlocked.Rows.Clear();

            foreach (Process p in osSimulator.listBlocked)
            {

                dtgBlocked.Rows.Add(
                    p.PID,
                    p.size,
                    p.programCounter,
                    p.priority,
                    p.timeBlock
                    );
            }
        }

        private void updateFinished()
        {
            dtgFinished.Rows.Clear();

            foreach (Process p in osSimulator.listFinished)
            {

                dtgFinished.Rows.Add(
                    p.PID,
                    p.size,
                    p.programCounter
                    );
            }
        }

        private void showProcess()
        {
            if (!osSimulator.cpus[0].IsIdle()){

                Process process = osSimulator.cpus[0].executingProcess;

                txtPID.Text =process.PID.ToString();
                txtSize.Text=process.size.ToString();
                txtPriority.Text=process.priority.ToString();
                txtPC.Text=process.programCounter.ToString();

            }
            else
            {
                txtPC.Clear();
                txtPID.Clear();
                txtSize.Clear();
                txtPriority.Clear();
            }
        }
    }
}
