﻿// EngineDisplayForm.cs - the user interface for the C# Editor

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;
using System.Xml;

using System.Windows.Forms.Design;

namespace LimanEditor
{
  
    public partial class EditorForm : Form
    {
        bool m_bInProject;

        public string m_projectName;
        public string m_projectDirectory;

        public EditorForm()
        {
            m_bInProject = false;

            InitializeComponent();

            try
            {
                // This is how we get the instance handle for our C# app.
                System.IntPtr hInstance = Marshal.GetHINSTANCE(this.GetType().Module);

                // This is how we get the window handle for the panel we'll be rendering into.
                IntPtr hwnd = this.DisplayPanel.Handle;

                // Call into our Dll main function, which will set up an instance of the EditorApp project.
                NativeMethods.EditorMain(hInstance, IntPtr.Zero, hwnd, 1, this.DisplayPanel.Width, this.DisplayPanel.Height);

                //InitializeAssetTree();

                //m_messageFilter = new MessageHandler(this.DisplayPanel, this);
                //m_ActorComponentEditor = new ActorComponentEditor(Panel_ActorComponents, m_ProjectDirectory);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.ToString());
            }
        }

        public void ShutDown()
        {
            // TODO: Check for changes being unsaved
            //const string message = "Are you sure that you would like to close the form?";
            //const string caption = "Form Closing";
            //var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //// If the no button was pressed ...
            //if (result == DialogResult.No)
            //{
            //    // cancel the closure of the form.
            //    //e.Cancel = true;
            //}

            NativeMethods.Shutdown();
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void viewSourceCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sourceCodeLink = "https://github.com/justbear/Liman/tree/master/Core";
            MenuStripUtils.OpenLink(sourceCodeLink);

        }

        private void openDocumentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string documentationLink = "http://matthewpoletin.ru/projects/Liman/Documentation";
            MenuStripUtils.OpenLink(documentationLink);

        }

        private void projectSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Open project settings form
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutForm aboutForm = new aboutForm();
            aboutForm.ShowDialog();
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProjectForm newProject = new NewProjectForm();
            newProject.ShowDialog();
        }

        private void DisplayPanel_Paint(object sender, PaintEventArgs e)
        {
            //NativeMethods.RenderFrame();
        }
    }
}
