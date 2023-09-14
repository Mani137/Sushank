﻿using System;
using System.Collections.Generic;
namespace BusinessLayer
{

    public class clsPlan
    {
        DataAccessLayerHelper.clsPlanData DBLayer;

        private int _SNo;
        private string _keywords;
        private int? _PlanId;
        private string _TimeRequired;
        private string _Description;
        private bool _IsActive;
        private bool _IsDeleted;
        private DateTime _CreatedOn;
        private int? _CreatedBy;

        public int SNo
        {
            get { return _SNo; }
            set { _SNo = value; }
        }
        public string keywords
        {
            get { return _keywords; }
            set { _keywords = value; }
        }

        public int? PlanId
        {
            get { return _PlanId; }
            set { _PlanId = value; }
        }
        public string TimeRequired
        {
            get { return _TimeRequired; }
            set { _TimeRequired = value; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
        public bool IsDeleted
        {
            get { return _IsDeleted; }
            set { _IsDeleted = value; }
        }
        public DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set { _CreatedOn = value; }
        }
        public int? CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }
        public clsPlan()
        {
            DBLayer = new DataAccessLayerHelper.clsPlanData();
        }
        public void AddUpdate(clsPlan obj)
        {
            DBLayer.AddUpdate(obj);
        }
        public clsPlan Load(int Id)
        {
            return DBLayer.Load(Id);
        }
        public List<clsPlan> LoadAll(clsPlan obj)
        {
            return DBLayer.LoadAll(obj);
        }
        public void Remove(int Id)
        {
            DBLayer.Remove(Id);
        }
    }
}