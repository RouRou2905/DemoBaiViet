﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyTinTuc.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="QuanLyBaiViet")]
	public partial class DataTableDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertpost(post instance);
    partial void Updatepost(post instance);
    partial void Deletepost(post instance);
    #endregion
		
		public DataTableDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["QuanLyBaiVietConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataTableDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataTableDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataTableDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataTableDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<post> posts
		{
			get
			{
				return this.GetTable<post>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.post")]
	public partial class post : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _title;
		
		private string _content;
		
		private string _script;
		
		private string _category;
		
		private string _imgName;
		
		private string _imgFile;
		
		private string _DateCreate;
		
		private System.Nullable<byte> _isDelete;
		
		private string _DeleteTime;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OntitleChanging(string value);
    partial void OntitleChanged();
    partial void OncontentChanging(string value);
    partial void OncontentChanged();
    partial void OnscriptChanging(string value);
    partial void OnscriptChanged();
    partial void OncategoryChanging(string value);
    partial void OncategoryChanged();
    partial void OnimgNameChanging(string value);
    partial void OnimgNameChanged();
    partial void OnimgFileChanging(string value);
    partial void OnimgFileChanged();
    partial void OnDateCreateChanging(string value);
    partial void OnDateCreateChanged();
    partial void OnisDeleteChanging(System.Nullable<byte> value);
    partial void OnisDeleteChanged();
    partial void OnDeleteTimeChanging(string value);
    partial void OnDeleteTimeChanged();
    #endregion
		
		public post()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_title", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string title
		{
			get
			{
				return this._title;
			}
			set
			{
				if ((this._title != value))
				{
					this.OntitleChanging(value);
					this.SendPropertyChanging();
					this._title = value;
					this.SendPropertyChanged("title");
					this.OntitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_content", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string content
		{
			get
			{
				return this._content;
			}
			set
			{
				if ((this._content != value))
				{
					this.OncontentChanging(value);
					this.SendPropertyChanging();
					this._content = value;
					this.SendPropertyChanged("content");
					this.OncontentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_script", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string script
		{
			get
			{
				return this._script;
			}
			set
			{
				if ((this._script != value))
				{
					this.OnscriptChanging(value);
					this.SendPropertyChanging();
					this._script = value;
					this.SendPropertyChanged("script");
					this.OnscriptChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_category", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string category
		{
			get
			{
				return this._category;
			}
			set
			{
				if ((this._category != value))
				{
					this.OncategoryChanging(value);
					this.SendPropertyChanging();
					this._category = value;
					this.SendPropertyChanged("category");
					this.OncategoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_imgName", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string imgName
		{
			get
			{
				return this._imgName;
			}
			set
			{
				if ((this._imgName != value))
				{
					this.OnimgNameChanging(value);
					this.SendPropertyChanging();
					this._imgName = value;
					this.SendPropertyChanged("imgName");
					this.OnimgNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_imgFile", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string imgFile
		{
			get
			{
				return this._imgFile;
			}
			set
			{
				if ((this._imgFile != value))
				{
					this.OnimgFileChanging(value);
					this.SendPropertyChanging();
					this._imgFile = value;
					this.SendPropertyChanged("imgFile");
					this.OnimgFileChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateCreate", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string DateCreate
		{
			get
			{
				return this._DateCreate;
			}
			set
			{
				if ((this._DateCreate != value))
				{
					this.OnDateCreateChanging(value);
					this.SendPropertyChanging();
					this._DateCreate = value;
					this.SendPropertyChanged("DateCreate");
					this.OnDateCreateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_isDelete", DbType="TinyInt")]
		public System.Nullable<byte> isDelete
		{
			get
			{
				return this._isDelete;
			}
			set
			{
				if ((this._isDelete != value))
				{
					this.OnisDeleteChanging(value);
					this.SendPropertyChanging();
					this._isDelete = value;
					this.SendPropertyChanged("isDelete");
					this.OnisDeleteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DeleteTime", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string DeleteTime
		{
			get
			{
				return this._DeleteTime;
			}
			set
			{
				if ((this._DeleteTime != value))
				{
					this.OnDeleteTimeChanging(value);
					this.SendPropertyChanging();
					this._DeleteTime = value;
					this.SendPropertyChanged("DeleteTime");
					this.OnDeleteTimeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
