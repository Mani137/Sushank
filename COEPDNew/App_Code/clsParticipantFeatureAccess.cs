﻿//This Class  is used to Set and Get the values of Participant Fields From Business Layer and Data Acess Layer
using DataAccessLayerHelper;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class clsParticipantFeatureAccess
    {
        clsParticipantFeatureAccessData DBLayer;

        private int _SNo;
        private string _keywords;
        private int? _FeatureAccessId;
        private int _ParticipantId;
        private int _FeatureId;
        private string _Feature;
        private int _ModuleId;
        private string _Module;
        private string _PageName;
        private bool _IsActive;
        private bool _IsDeleted;
        private DateTime _CreatedOn;
        private int _CreatedBy;
        private string _SendAssignedFeaturesToParticipant;

        public int SNo
        {
            get { return _SNo; }
            set { _SNo = value; }
        }

        public string Keywords
        {
            get { return _keywords; }
            set { _keywords = value; }
        }

        public int? FeatureAccessId
        {
            get { return _FeatureAccessId; }
            set { _FeatureAccessId = value; }
        }

        public int ParticipantId
        {
            get { return _ParticipantId; }
            set { _ParticipantId = value; }
        }

        public int FeatureId
        {
            get { return _FeatureId; }
            set { _FeatureId = value; }
        }

        public string Feature
        {
            get { return _Feature; }
            set { _Feature = value; }
        }

        public int ModuleId
        {
            get { return _ModuleId; }
            set { _ModuleId = value; }
        }

        public string Module
        {
            get { return _Module; }
            set { _Module = value; }
        }

        public string PageName
        {
            get { return _PageName; }
            set { _PageName = value; }
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

        public int CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }

        public string SendAssignedFeaturesToParticipant
        {
            get { return _SendAssignedFeaturesToParticipant; }
            set { _SendAssignedFeaturesToParticipant = value; }
        }

        public clsParticipantFeatureAccess()
        {
            DBLayer = new DataAccessLayerHelper.clsParticipantFeatureAccessData();
        }

        public void AddUpdate(clsParticipantFeatureAccess obj)
        {
            DBLayer.AddUpdate(obj);
        }
        //This Method is not used now.
        //public clsParticipantFeatureAccess Load(int Id)
        //{
        //    return DBLayer.Load(Id);
        //}       

        public List<clsParticipantFeatureAccess> LoadAll(clsParticipantFeatureAccess obj)
        {
            return DBLayer.LoadAll(obj);
        }

        public void RemoveByParticipant(clsParticipantFeatureAccess obj)
        {
            DBLayer.RemoveByParticipant(obj);
        }
        public void Remove(clsParticipantFeatureAccess obj)
        {
            DBLayer.Remove(obj);
        }
        public int ParticipantFeatureValidation(clsParticipantFeatureAccess obj)
        {
            return DBLayer.ParticipantFeatureValidation(obj);
        }
        public clsParticipantFeatureAccess LoadParticipantAssignedFeatures(int ParticiantId)
        {
            return DBLayer.LoadParticipantAssignedFeatures(ParticiantId);
        }
    }
}
