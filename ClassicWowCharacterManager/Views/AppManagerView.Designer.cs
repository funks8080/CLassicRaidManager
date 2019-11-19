namespace ClassicWowCharacterManager.Views
{
    partial class AppManagerView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgRaids = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgProfs = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dgItemTypes = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.dgItemRarity = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.dgRank = new System.Windows.Forms.DataGridView();
            this.btnDeleteRaid = new System.Windows.Forms.Button();
            this.btnDeleteProf = new System.Windows.Forms.Button();
            this.btnDeleteType = new System.Windows.Forms.Button();
            this.btnDeleteRarity = new System.Windows.Forms.Button();
            this.btnDeleteRank = new System.Windows.Forms.Button();
            this.btnDeleteRole = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dgRoles = new System.Windows.Forms.DataGridView();
            this.ProfID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProfName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RaidID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RaidName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RarityID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RarityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RankID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RankName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RankDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoleDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgRaids)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProfs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItemTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItemRarity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add New";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgRaids
            // 
            this.dgRaids.AllowUserToAddRows = false;
            this.dgRaids.AllowUserToDeleteRows = false;
            this.dgRaids.AllowUserToResizeRows = false;
            this.dgRaids.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRaids.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RaidID,
            this.RaidName});
            this.dgRaids.Location = new System.Drawing.Point(6, 46);
            this.dgRaids.MultiSelect = false;
            this.dgRaids.Name = "dgRaids";
            this.dgRaids.ReadOnly = true;
            this.dgRaids.RowHeadersVisible = false;
            this.dgRaids.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgRaids.Size = new System.Drawing.Size(268, 79);
            this.dgRaids.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Raid Groups:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Professions:";
            // 
            // dgProfs
            // 
            this.dgProfs.AllowUserToAddRows = false;
            this.dgProfs.AllowUserToDeleteRows = false;
            this.dgProfs.AllowUserToResizeRows = false;
            this.dgProfs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProfs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProfID,
            this.ProfName});
            this.dgProfs.Location = new System.Drawing.Point(278, 46);
            this.dgProfs.MultiSelect = false;
            this.dgProfs.Name = "dgProfs";
            this.dgProfs.ReadOnly = true;
            this.dgProfs.RowHeadersVisible = false;
            this.dgProfs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProfs.Size = new System.Drawing.Size(268, 79);
            this.dgProfs.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Item Slots or Types:";
            // 
            // dgItemTypes
            // 
            this.dgItemTypes.AllowUserToAddRows = false;
            this.dgItemTypes.AllowUserToDeleteRows = false;
            this.dgItemTypes.AllowUserToResizeRows = false;
            this.dgItemTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItemTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TypeID,
            this.TypeName});
            this.dgItemTypes.Location = new System.Drawing.Point(6, 160);
            this.dgItemTypes.MultiSelect = false;
            this.dgItemTypes.Name = "dgItemTypes";
            this.dgItemTypes.ReadOnly = true;
            this.dgItemTypes.RowHeadersVisible = false;
            this.dgItemTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgItemTypes.Size = new System.Drawing.Size(268, 79);
            this.dgItemTypes.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(277, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Item Rarity:";
            // 
            // dgItemRarity
            // 
            this.dgItemRarity.AllowUserToAddRows = false;
            this.dgItemRarity.AllowUserToDeleteRows = false;
            this.dgItemRarity.AllowUserToResizeRows = false;
            this.dgItemRarity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItemRarity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RarityID,
            this.RarityName});
            this.dgItemRarity.Location = new System.Drawing.Point(278, 160);
            this.dgItemRarity.MultiSelect = false;
            this.dgItemRarity.Name = "dgItemRarity";
            this.dgItemRarity.ReadOnly = true;
            this.dgItemRarity.RowHeadersVisible = false;
            this.dgItemRarity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgItemRarity.Size = new System.Drawing.Size(268, 79);
            this.dgItemRarity.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Ranks:";
            // 
            // dgRank
            // 
            this.dgRank.AllowUserToAddRows = false;
            this.dgRank.AllowUserToDeleteRows = false;
            this.dgRank.AllowUserToResizeRows = false;
            this.dgRank.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRank.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RankID,
            this.RankName,
            this.RankDesc});
            this.dgRank.Location = new System.Drawing.Point(6, 274);
            this.dgRank.MultiSelect = false;
            this.dgRank.Name = "dgRank";
            this.dgRank.ReadOnly = true;
            this.dgRank.RowHeadersVisible = false;
            this.dgRank.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgRank.Size = new System.Drawing.Size(268, 79);
            this.dgRank.TabIndex = 9;
            // 
            // btnDeleteRaid
            // 
            this.btnDeleteRaid.Location = new System.Drawing.Point(197, 131);
            this.btnDeleteRaid.Name = "btnDeleteRaid";
            this.btnDeleteRaid.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteRaid.TabIndex = 11;
            this.btnDeleteRaid.Text = "Delete";
            this.btnDeleteRaid.UseVisualStyleBackColor = true;
            this.btnDeleteRaid.Click += new System.EventHandler(this.btnDeleteRaid_Click);
            // 
            // btnDeleteProf
            // 
            this.btnDeleteProf.Location = new System.Drawing.Point(471, 131);
            this.btnDeleteProf.Name = "btnDeleteProf";
            this.btnDeleteProf.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteProf.TabIndex = 12;
            this.btnDeleteProf.Text = "Delete";
            this.btnDeleteProf.UseVisualStyleBackColor = true;
            this.btnDeleteProf.Click += new System.EventHandler(this.btnDeleteProf_Click);
            // 
            // btnDeleteType
            // 
            this.btnDeleteType.Location = new System.Drawing.Point(197, 245);
            this.btnDeleteType.Name = "btnDeleteType";
            this.btnDeleteType.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteType.TabIndex = 13;
            this.btnDeleteType.Text = "Delete";
            this.btnDeleteType.UseVisualStyleBackColor = true;
            this.btnDeleteType.Click += new System.EventHandler(this.btnDeleteType_Click);
            // 
            // btnDeleteRarity
            // 
            this.btnDeleteRarity.Location = new System.Drawing.Point(475, 245);
            this.btnDeleteRarity.Name = "btnDeleteRarity";
            this.btnDeleteRarity.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteRarity.TabIndex = 14;
            this.btnDeleteRarity.Text = "Delete";
            this.btnDeleteRarity.UseVisualStyleBackColor = true;
            this.btnDeleteRarity.Click += new System.EventHandler(this.btnDeleteRarity_Click);
            // 
            // btnDeleteRank
            // 
            this.btnDeleteRank.Location = new System.Drawing.Point(197, 359);
            this.btnDeleteRank.Name = "btnDeleteRank";
            this.btnDeleteRank.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteRank.TabIndex = 15;
            this.btnDeleteRank.Text = "Delete";
            this.btnDeleteRank.UseVisualStyleBackColor = true;
            this.btnDeleteRank.Click += new System.EventHandler(this.btnDeleteRank_Click);
            // 
            // btnDeleteRole
            // 
            this.btnDeleteRole.Location = new System.Drawing.Point(471, 359);
            this.btnDeleteRole.Name = "btnDeleteRole";
            this.btnDeleteRole.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteRole.TabIndex = 18;
            this.btnDeleteRole.Text = "Delete";
            this.btnDeleteRole.UseVisualStyleBackColor = true;
            this.btnDeleteRole.Click += new System.EventHandler(this.btnDeleteRole_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(279, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Raid Roles:";
            // 
            // dgRoles
            // 
            this.dgRoles.AllowUserToAddRows = false;
            this.dgRoles.AllowUserToDeleteRows = false;
            this.dgRoles.AllowUserToResizeRows = false;
            this.dgRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RoleID,
            this.RoleName,
            this.RoleDesc});
            this.dgRoles.Location = new System.Drawing.Point(278, 274);
            this.dgRoles.MultiSelect = false;
            this.dgRoles.Name = "dgRoles";
            this.dgRoles.ReadOnly = true;
            this.dgRoles.RowHeadersVisible = false;
            this.dgRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgRoles.Size = new System.Drawing.Size(268, 79);
            this.dgRoles.TabIndex = 16;
            // 
            // ProfID
            // 
            this.ProfID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProfID.FillWeight = 20F;
            this.ProfID.HeaderText = "ID";
            this.ProfID.Name = "ProfID";
            this.ProfID.ReadOnly = true;
            // 
            // ProfName
            // 
            this.ProfName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProfName.HeaderText = "Name";
            this.ProfName.Name = "ProfName";
            this.ProfName.ReadOnly = true;
            // 
            // RaidID
            // 
            this.RaidID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RaidID.FillWeight = 20F;
            this.RaidID.HeaderText = "ID";
            this.RaidID.Name = "RaidID";
            this.RaidID.ReadOnly = true;
            // 
            // RaidName
            // 
            this.RaidName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RaidName.HeaderText = "Name";
            this.RaidName.Name = "RaidName";
            this.RaidName.ReadOnly = true;
            // 
            // TypeID
            // 
            this.TypeID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TypeID.FillWeight = 20F;
            this.TypeID.HeaderText = "ID";
            this.TypeID.Name = "TypeID";
            this.TypeID.ReadOnly = true;
            // 
            // TypeName
            // 
            this.TypeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TypeName.HeaderText = "Name";
            this.TypeName.Name = "TypeName";
            this.TypeName.ReadOnly = true;
            // 
            // RarityID
            // 
            this.RarityID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RarityID.FillWeight = 20F;
            this.RarityID.HeaderText = "ID";
            this.RarityID.Name = "RarityID";
            this.RarityID.ReadOnly = true;
            // 
            // RarityName
            // 
            this.RarityName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RarityName.HeaderText = "Name";
            this.RarityName.Name = "RarityName";
            this.RarityName.ReadOnly = true;
            // 
            // RankID
            // 
            this.RankID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RankID.FillWeight = 20F;
            this.RankID.HeaderText = "ID";
            this.RankID.Name = "RankID";
            this.RankID.ReadOnly = true;
            // 
            // RankName
            // 
            this.RankName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RankName.FillWeight = 80F;
            this.RankName.HeaderText = "Name";
            this.RankName.Name = "RankName";
            this.RankName.ReadOnly = true;
            // 
            // RankDesc
            // 
            this.RankDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RankDesc.HeaderText = "Description";
            this.RankDesc.Name = "RankDesc";
            this.RankDesc.ReadOnly = true;
            // 
            // RoleID
            // 
            this.RoleID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RoleID.FillWeight = 20F;
            this.RoleID.HeaderText = "ID";
            this.RoleID.Name = "RoleID";
            this.RoleID.ReadOnly = true;
            // 
            // RoleName
            // 
            this.RoleName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RoleName.FillWeight = 80F;
            this.RoleName.HeaderText = "Name";
            this.RoleName.Name = "RoleName";
            this.RoleName.ReadOnly = true;
            // 
            // RoleDesc
            // 
            this.RoleDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RoleDesc.HeaderText = "Description";
            this.RoleDesc.Name = "RoleDesc";
            this.RoleDesc.ReadOnly = true;
            // 
            // AppManagerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDeleteRole);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgRoles);
            this.Controls.Add(this.btnDeleteRank);
            this.Controls.Add(this.btnDeleteRarity);
            this.Controls.Add(this.btnDeleteType);
            this.Controls.Add(this.btnDeleteProf);
            this.Controls.Add(this.btnDeleteRaid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgRank);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgItemRarity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgItemTypes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgProfs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgRaids);
            this.Controls.Add(this.btnAdd);
            this.Name = "AppManagerView";
            this.Size = new System.Drawing.Size(550, 400);
            ((System.ComponentModel.ISupportInitialize)(this.dgRaids)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProfs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItemTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgItemRarity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRoles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgRaids;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgProfs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgItemTypes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgItemRarity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgRank;
        private System.Windows.Forms.Button btnDeleteRaid;
        private System.Windows.Forms.Button btnDeleteProf;
        private System.Windows.Forms.Button btnDeleteType;
        private System.Windows.Forms.Button btnDeleteRarity;
        private System.Windows.Forms.Button btnDeleteRank;
        private System.Windows.Forms.Button btnDeleteRole;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgRoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn RaidID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RaidName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProfID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProfName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RarityID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RarityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RankID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RankName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RankDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoleDesc;
    }
}
