﻿
namespace Presentacion
{
    partial class ReportPrestamos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSetPrincipal = new Presentacion.DataSetPrincipal();
            this.sp_filtrarPrestamosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_filtrarPrestamosTableAdapter = new Presentacion.DataSetPrincipalTableAdapters.sp_filtrarPrestamosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_filtrarPrestamosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetPrestamos";
            reportDataSource1.Value = this.sp_filtrarPrestamosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Presentacion.Report.ReportPrestamos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(802, 723);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSetPrincipal
            // 
            this.DataSetPrincipal.DataSetName = "DataSetPrincipal";
            this.DataSetPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sp_filtrarPrestamosBindingSource
            // 
            this.sp_filtrarPrestamosBindingSource.DataMember = "sp_filtrarPrestamos";
            this.sp_filtrarPrestamosBindingSource.DataSource = this.DataSetPrincipal;
            // 
            // sp_filtrarPrestamosTableAdapter
            // 
            this.sp_filtrarPrestamosTableAdapter.ClearBeforeFill = true;
            // 
            // ReportPrestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 723);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportPrestamos";
            this.Text = "ReportPrestamos";
            this.Load += new System.EventHandler(this.ReportPrestamos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSetPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_filtrarPrestamosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_filtrarPrestamosBindingSource;
        private DataSetPrincipal DataSetPrincipal;
        private DataSetPrincipalTableAdapters.sp_filtrarPrestamosTableAdapter sp_filtrarPrestamosTableAdapter;
    }
}