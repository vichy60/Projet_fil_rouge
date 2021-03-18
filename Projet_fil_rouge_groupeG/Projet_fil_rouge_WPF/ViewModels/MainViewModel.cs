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
        public int CodePatient { get => Patient.CodePatient; set { Patient.CodePatient = value; RaisePropertyChanged(); } }
        public string NomPatient { get => Patient.NomPatient; set { Patient.NomPatient = value; RaisePropertyChanged(); } }
        public string AdressePatient { get => Patient.AdressePatient; set { Patient.AdressePatient = value; RaisePropertyChanged(); } }
        public DateTime DateNaissance { get => Patient.DateNaissance; set { Patient.DateNaissance = value; RaisePropertyChanged(); } }
        public ObservableCollection<Patient> Patients { get; set; }
        public bool M { get { return Patient.SexePatient != null ? Patient.SexePatient.Contains('M') : false; } set { Patient.SexePatient = value ? "M" : "F"; } }
        public bool F { get { return Patient.SexePatient != null ? Patient.SexePatient.Contains('F') : false; } set { Patient.SexePatient = value ? "F" : "M"; } }
        //ou {value==true? SexePatient="M" : SexePatient "F" }



        #endregion

        #region partie médecin
        public Medecin Medecin { get => medecin; set { medecin = value; if (value != null) RaiseAllChangedMedecin(); } }
        public int CodeMedecin { get => Medecin.CodeMedecin; set { Medecin.CodeMedecin = value; RaisePropertyChanged(); } }
        public string NomMedecin { get => Medecin.NomMedecin; set { Medecin.NomMedecin = value; RaisePropertyChanged(); } }
        public string TelMedecin { get => Medecin.TelMedecin; set { Medecin.TelMedecin = value; RaisePropertyChanged(); } }
        public DateTime DateEmbauche { get => Medecin.DateEmbauche; set { Medecin.DateEmbauche = value; RaisePropertyChanged(); } }
        public int SpecialiteId { get => Medecin.SpecialiteMedecinId; set { Medecin.SpecialiteMedecinId = value; RaisePropertyChanged(); } }
        public ObservableCollection<Medecin> Medecins { get; set; }




        #endregion


        #region partie Rendez-Vous
        public RDV Rdv { get => rdv; set => rdv = value; }
        public DateTime DateRDV { get => Rdv.DateRDV; set => Rdv.DateRDV = value; }

        #endregion

        public Specialite Spe { get => spe; set => spe = value; }

        public ObservableCollection<Specialite> Specialites { get; set; }




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




        public ICommand MenuRDVCommand { get; set; }
        public ICommand MenuQuitterCommand { get; set; }
        public MainViewModel()
        {
            Patient = new Patient();
            Medecin = new Medecin();
            Rdv = new RDV();
            spe = new Specialite();

            #region RelayCommand Patient

            NouveauPatientCommand = new RelayCommand(ActionNouveauPatientCommand);
            AjoutPatientCommand = new RelayCommand(ActionAjoutPatientCommand);
            RecherchePatientCommand = new RelayCommand(ActionRecherchePatientCommand);
            SupprimerPatientCommand = new RelayCommand(ActionSupprimerPatientCommand);
            ModifierPatientCommand = new RelayCommand(ActionModifierPatientCommand);
            QuitterPatientCommand = new RelayCommand(ActionQuitterPatientCommand);
            Patients = new ObservableCollection<Patient>(Patient.GetPatients());
            MenuPatientCommand = new RelayCommand(ActionMenuPatientCommand);
            #endregion

            #region RelayCommand Medecin
            NouveauMedecinCommand = new RelayCommand(ActionNouveauMedecinCommand);
            AjouterMedecinCommand = new RelayCommand(ActionAjouterMedecinCommand);
            RechercherMedecinCommand = new RelayCommand(ActionRechercherMedecinCommand);
            SupprimerMedecinCommand = new RelayCommand(ActionSupprimerMedecinCommand);
            ModifierMedecinCommand = new RelayCommand(ActionModifierMedecinCommand);
            QuitterMedecinCommand = new RelayCommand(ActionQuitterMedecinCommand);
            Medecins = new ObservableCollection<Medecin>(Medecin.GetMedecins());

            MenuMedecinCommand = new RelayCommand(ActionMenuMedecinCommand);
            #endregion


            MenuRDVCommand = new RelayCommand(ActionMenuRDVCommand);
            MenuQuitterCommand = new RelayCommand(ActionMenuQuitterCommand);
            DateNaissance = DateTime.Now;
            DateEmbauche = DateTime.Now;
            Specialites = new ObservableCollection<Specialite>(Specialite.GetListSpecialite());

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


        #endregion
        public void ActionQuitterMedecinCommand()
        {
            VisibilityMedecin = Visibility.Collapsed;
        }


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

        private void RaiseAllChangedPatient()
        {
            RaisePropertyChanged("CodePatient");
            RaisePropertyChanged("NomPatient");
            RaisePropertyChanged("AdressePatient");
            RaisePropertyChanged("DateNaissance");
            RaisePropertyChanged("M");
            RaisePropertyChanged("F");
        }

        private void RaiseAllChangedMedecin()
        {
            RaisePropertyChanged("CodeMedecin");
            RaisePropertyChanged("NomMedecin");
            RaisePropertyChanged("TelMedecin");
            RaisePropertyChanged("DateEmbauche");
            RaisePropertyChanged("Spe");


        }



    }
}
