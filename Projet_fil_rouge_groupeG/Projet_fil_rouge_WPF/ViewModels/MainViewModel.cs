using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;
using Projet_fil_rouge_groupeG.Classes;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;

namespace Projet_fil_rouge_WPF.ViewModels
{


    public class MainViewModel : ViewModelBase
    {
        private Patient patient;
        private Medecin medecin;
        private RDV rdv;
        private Specialite spe;
        private Visibility visibilityPatient = Visibility.Collapsed;
        private Visibility visibilityMedecin = Visibility.Collapsed;
        private Visibility visibilityRDV = Visibility.Collapsed;

        #region partie patient
        public Patient Patient { get => patient; set { patient = value; if (value != null) RaiseAllChangedPatient(); } }
        public int CodePatient { get => (Patient!=null)? Patient.CodePatient :0; set { Patient.CodePatient = value; RaisePropertyChanged(); } }
        public string NomPatient { get => (Patient!=null)?Patient.NomPatient : null; set { Patient.NomPatient = value; RaisePropertyChanged(); } }
        public string AdressePatient { get => (Patient!=null)? Patient.AdressePatient : null; set { Patient.AdressePatient = value; RaisePropertyChanged(); } }
        public DateTime DateNaissance { get =>(Patient!=null)? Patient.DateNaissance: DateTime.Now; set { Patient.DateNaissance = value; RaisePropertyChanged(); } }
        public ObservableCollection<Patient> Patients { get; set; }
        public bool M { get { return (Patient!=null) ? (Patient.SexePatient != null ? Patient.SexePatient.Contains('M') : false) : false; } set { Patient.SexePatient = value ? "M" : "F"; } }
        public bool F { get { return (Patient != null) ? (Patient.SexePatient != null ? Patient.SexePatient.Contains('F') : false) : false; } set { Patient.SexePatient = value ? "F" : "M"; } }
        //ou {value==true? SexePatient="M" : SexePatient "F" }



        #endregion

        #region partie médecin
        public Medecin Medecin { get => medecin; set { medecin = value; if (value != null) RaiseAllChangedMedecin(); } }
        public int CodeMedecin { get => (Medecin != null)? Medecin.CodeMedecin : 0; set { Medecin.CodeMedecin = value; RaisePropertyChanged(); } }
        public string NomMedecin { get => (Medecin != null) ? Medecin.NomMedecin : null; set { Medecin.NomMedecin = value; RaisePropertyChanged(); } }
        public string TelMedecin { get => (Medecin != null) ? Medecin.TelMedecin : null; set { Medecin.TelMedecin = value; RaisePropertyChanged(); } }
        public DateTime DateEmbauche { get => (Medecin != null) ? Medecin.DateEmbauche : DateTime.Now; set { Medecin.DateEmbauche = value; RaisePropertyChanged(); } }
        public int SpecialiteId { get => (Medecin !=null)? Medecin.SpecialiteMedecinId : 0 ; set { Medecin.SpecialiteMedecinId = value; RaisePropertyChanged(); } }
        public Specialite SpeRdv { get => (Medecin !=null)? Specialite.GetSpecialite(Medecin.SpecialiteMedecinId):null; }
        public ObservableCollection<Medecin> Medecins { get; set; }




        #endregion


        #region partie Rendez-Vous
        public RDV Rdv { get => rdv; set { rdv = value; if (value != null) RaiseAllChangedRdv(); } }
        public DateTime DateRDV { get => Rdv.DateRDV; set { Rdv.DateRDV = value; RaisePropertyChanged(); } }
        public int NumRDV { get => Rdv.NumeroRDV; set { Rdv.NumeroRDV = value; RaisePropertyChanged(); } }
        public string HeureRDV { get => Rdv.HeureRDV; set { Rdv.HeureRDV = value; RaisePropertyChanged(); } }
        public int RDVMedecinId { get => Rdv.MedecinId; set { Rdv.MedecinId = value; RaisePropertyChanged(); } }
        public int RDVPatientId { get => Rdv.PatientId; set { Rdv.PatientId = value; RaisePropertyChanged(); } }


        public ObservableCollection<RDV> Rdvs { get; set; }

        #endregion

        #region partie Spécialité
        public Specialite Spe { get => spe; set { spe = value; RaisePropertyChanged(); } }

        public ObservableCollection<Specialite> Specialites { get; set; }
        #endregion



        public Visibility VisibilityPatient { get => visibilityPatient; set { visibilityPatient = value; RaisePropertyChanged(); } }
        public Visibility VisibilityMedecin { get => visibilityMedecin; set { visibilityMedecin = value; RaisePropertyChanged(); } }
        public Visibility VisibilityRDV { get => visibilityRDV; set { visibilityRDV = value; RaisePropertyChanged(); } }

        #region ICommand Patient
        public ICommand AjoutPatientCommand { get; set; }
        public ICommand NouveauPatientCommand { get; set; }
        public ICommand RecherchePatientCommand { get; set; }
        public ICommand QuitterPatientCommand { get; set; }
        public ICommand SupprimerPatientCommand { get; set; }
        public ICommand ModifierPatientCommand { get; set; }
        public ICommand MenuPatientCommand { get; set; }
        #endregion

        #region ICommand Medecin
        public ICommand AjouterMedecinCommand { get; set; }
        public ICommand NouveauMedecinCommand { get; set; }
        public ICommand RechercherMedecinCommand { get; set; }
        public ICommand QuitterMedecinCommand { get; set; }
        public ICommand SupprimerMedecinCommand { get; set; }
        public ICommand ModifierMedecinCommand { get; set; }

        public ICommand MenuMedecinCommand { get; set; }
        #endregion

        #region ICommand RDV

        public ICommand AjouterRDVCommand { get; set; }
        public ICommand NouveauRDVCommand { get; set; }

        public ICommand QuitterRDVCommand { get; set; }
        #endregion


        public ICommand MenuRDVCommand { get; set; }
        public ICommand MenuQuitterCommand { get; set; }
        public MainViewModel()
        {
            Patient = new Patient();
            Medecin = new Medecin();
            Rdv = new RDV();
            spe = new Specialite();
            Patients = new ObservableCollection<Patient>(Patient.GetPatients());
            Medecins = new ObservableCollection<Medecin>(Medecin.GetMedecins());
            Specialites = new ObservableCollection<Specialite>(Specialite.GetListSpecialite());
            Rdvs = new ObservableCollection<RDV>(RDV.GetRdvs());
            #region RelayCommand Patient

            NouveauPatientCommand = new RelayCommand(ActionNouveauPatientCommand);
            AjoutPatientCommand = new RelayCommand(ActionAjoutPatientCommand);
            RecherchePatientCommand = new RelayCommand(ActionRecherchePatientCommand);
            SupprimerPatientCommand = new RelayCommand(ActionSupprimerPatientCommand);
            ModifierPatientCommand = new RelayCommand(ActionModifierPatientCommand);
            QuitterPatientCommand = new RelayCommand(ActionQuitterPatientCommand);


            #endregion

            #region RelayCommand Medecin
            NouveauMedecinCommand = new RelayCommand(ActionNouveauMedecinCommand);
            AjouterMedecinCommand = new RelayCommand(ActionAjouterMedecinCommand);
            RechercherMedecinCommand = new RelayCommand(ActionRechercherMedecinCommand);
            SupprimerMedecinCommand = new RelayCommand(ActionSupprimerMedecinCommand);
            ModifierMedecinCommand = new RelayCommand(ActionModifierMedecinCommand);
            QuitterMedecinCommand = new RelayCommand(ActionQuitterMedecinCommand);



            #endregion

            #region RelayCommand RDV

            NouveauRDVCommand = new RelayCommand(ActionNouveauRDVCommand);
            AjouterRDVCommand = new RelayCommand(ActionAjouterRDVCommand);
            QuitterRDVCommand = new RelayCommand(ActionQuitterRDVCommand);
            #endregion

            #region RelayCommand Menu
            MenuPatientCommand = new RelayCommand(ActionMenuPatientCommand);
            MenuMedecinCommand = new RelayCommand(ActionMenuMedecinCommand);
            MenuRDVCommand = new RelayCommand(ActionMenuRDVCommand);
            MenuQuitterCommand = new RelayCommand(ActionMenuQuitterCommand);
            #endregion
            DateNaissance = DateTime.Now;
            DateEmbauche = DateTime.Now;
            DateRDV = DateTime.Now;

        }


        #region Action Patient
        public void ActionNouveauPatientCommand()
        {
            patient = new Patient();
            DateNaissance = DateTime.Now;
            RaiseAllChangedPatient();
        }
        public void ActionAjoutPatientCommand()
        {

            if (CodePatient <= 0 && !string.IsNullOrEmpty(NomPatient) && !string.IsNullOrEmpty(AdressePatient) && DateNaissance != null && !string.IsNullOrEmpty(Patient.SexePatient) && Patient.Save())
            {
                Patients.Add(Patient);
                MessageBox.Show("Patient ajouté");
                Patient = new Patient();
                DateNaissance = DateTime.Now;
                RaiseAllChangedPatient();
            }
            else
                MessageBox.Show("Veuillez saisir tout les champs !", "erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

        public void ActionRecherchePatientCommand()
        {
            Patient P = Patient.GetPatientById(CodePatient);
            if (P != null)
            {
                Patient = P;
                RaiseAllChangedPatient();
            }
            else
                MessageBox.Show("Le patient n'existe pas, veuillez saisir un code valide !", "erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public void ActionSupprimerPatientCommand()
        {
            Patient p = Patient.GetPatientById(CodePatient);
            if (p != null)
            {
                patient = p;
                patient.Delete();
                patient = new Patient();
                DateNaissance = DateTime.Now;
                RaiseAllChangedPatient();
            }
            else
                MessageBox.Show("Veuillez saisir le bon code patient à supprimer !", "erreur de suppression", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

        public void ActionModifierPatientCommand()
        {
            Patient p = Patient.GetPatientById(CodePatient);
            if (p != null && !string.IsNullOrEmpty(NomPatient) && !string.IsNullOrEmpty(AdressePatient) && DateNaissance != null && !string.IsNullOrEmpty(Patient.SexePatient))
            {
                patient.Update();
                RaiseAllChangedPatient();
                MessageBox.Show("Modification effectuée!", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
                MessageBox.Show("Veuillez saisir le bon code patient à modifier ainsi que tous les champs !", "erreur de modification", MessageBoxButton.OK, MessageBoxImage.Warning);


        }
        public void ActionQuitterPatientCommand()
        {
            VisibilityPatient = Visibility.Collapsed;
        }

        #endregion

        #region Action Medecin
        public void ActionNouveauMedecinCommand()
        {
            medecin = new Medecin();
            DateEmbauche = DateTime.Now;
            Spe = null;

            RaiseAllChangedMedecin();
        }
        public void ActionAjouterMedecinCommand()
        {

            if (CodeMedecin <= 0 && !string.IsNullOrEmpty(NomMedecin) && !string.IsNullOrEmpty(TelMedecin) && DateEmbauche != null && Spe != null)
            {

                SpecialiteId = Spe.Id;
                Medecin.Save();
                Medecins.Add(Medecin);
                MessageBox.Show("Medecin ajouté", "success", MessageBoxButton.OK, MessageBoxImage.Information);
                Medecin = new Medecin();
                DateEmbauche = DateTime.Now;
                RaiseAllChangedMedecin();
            }
            else
                MessageBox.Show("Veuillez saisir tout les champs !", "erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

        public void ActionRechercherMedecinCommand()
        {
            Medecin m = Medecin.GetMedecinById(CodeMedecin);
            if (m != null)
            {
                Medecin = m;
                Spe = Specialites.FirstOrDefault(s => s.Id == SpecialiteId);
                RaiseAllChangedMedecin();
            }
            else
                MessageBox.Show("Le medecin n'existe pas, veuillez saisir un code valide !", "erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public void ActionSupprimerMedecinCommand()
        {
            Medecin m = Medecin.GetMedecinById(CodeMedecin);
            if (m != null)
            {
                Medecin = m;
                Medecin.Delete();
                medecin = new Medecin();
                DateEmbauche = DateTime.Now;
                RaiseAllChangedMedecin();
            }
            else
                MessageBox.Show("Veuillez saisir le bon code patient à supprimer !", "erreur de suppression", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

        public void ActionModifierMedecinCommand()
        {
            Medecin m = Medecin.GetMedecinById(CodeMedecin);
            if (m != null && !string.IsNullOrEmpty(NomMedecin) && !string.IsNullOrEmpty(TelMedecin) && DateEmbauche != null && Spe != null)
            {
                SpecialiteId = Spe.Id;
                if (Medecin.Update())
                {
                    RaiseAllChangedPatient();
                    MessageBox.Show("Modification effectuée!", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }

            }
            else
                MessageBox.Show("Veuillez saisir le bon code patient à modifier ainsi que tous les champs !", "erreur de modification", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public void ActionQuitterMedecinCommand()
        {
            VisibilityMedecin = Visibility.Collapsed;
        }

        #endregion

        #region Action RDV
        public void ActionNouveauRDVCommand()
        {
            Rdv = new RDV();
           Patient = null;
            Medecin = null;
            DateRDV = DateTime.Now;

            RaiseAllChangedMedecin();
            RaiseAllChangedPatient();
            RaiseAllChangedRdv();

        }



        public void ActionAjouterRDVCommand()
        {
           

            RDVMedecinId = Medecin.CodeMedecin;
            RDVPatientId = Patient.CodePatient;



            if (NumRDV <= 0 && RDVMedecinId > 0 && RDVPatientId > 0 && DateRDV != null && !string.IsNullOrEmpty(HeureRDV))
            {
                if (rdv.Save())
                {
                    Rdvs.Add(rdv);
                    MessageBox.Show("Le Rendez-vous a été ajouté !", "success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Problème  enregistrement dans la base!", "erreur Enregistrement", MessageBoxButton.OK, MessageBoxImage.Warning);
                //Rdv = new RDV();
                //DateRDV = DateTime.Now;
                //RaiseAllChangedRdv();
            }
            else
                MessageBox.Show("Veuillez saisir tout les champs !", "erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);




        }

        public void ActionQuitterRDVCommand()
        {
            VisibilityRDV = Visibility.Collapsed;
        }
        #endregion

        #region Action Menu Général
        public void ActionMenuPatientCommand()
        {
            VisibilityMedecin = Visibility.Collapsed;
            VisibilityRDV = Visibility.Collapsed;
            VisibilityPatient = Visibility.Visible;
        }
        public void ActionMenuMedecinCommand()
        {
            VisibilityMedecin = Visibility.Visible;
            VisibilityRDV = Visibility.Collapsed;
            VisibilityPatient = Visibility.Collapsed;
        }
        public void ActionMenuRDVCommand()
        {
            VisibilityMedecin = Visibility.Collapsed;
            VisibilityRDV = Visibility.Visible;
            VisibilityPatient = Visibility.Collapsed;
        }

        public void ActionMenuQuitterCommand()
        {
            Environment.Exit(0);
        }

        #endregion
        private void RaiseAllChangedPatient()
        {
            RaisePropertyChanged("Patient");
            RaisePropertyChanged("CodePatient");
            RaisePropertyChanged("NomPatient");
            RaisePropertyChanged("AdressePatient");
            RaisePropertyChanged("DateNaissance");
            RaisePropertyChanged("M");
            RaisePropertyChanged("F");
        }

        private void RaiseAllChangedMedecin()
        {
            RaisePropertyChanged("Medecin");
            RaisePropertyChanged("CodeMedecin");
            RaisePropertyChanged("NomMedecin");
            RaisePropertyChanged("TelMedecin");
            RaisePropertyChanged("DateEmbauche");
            RaisePropertyChanged("Spe");
            RaisePropertyChanged("SpeRdv");


        }

        private void RaiseAllChangedRdv()
        {
            RaisePropertyChanged("NumRDV");
            RaisePropertyChanged("DateRDV");
            RaisePropertyChanged("HeureRDV");


        }



    }
}
