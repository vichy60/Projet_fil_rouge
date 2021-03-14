using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;
using Projet_fil_rouge_groupeG.Classes;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows;

namespace Projet_fil_rouge_WPF.ViewModels
{


    public class MainViewModel : ViewModelBase
    {
        private Patient patient;
        private Medecin medecin;
        private RDV rdv;
        private Specialite spe;
        private Visibility visibilityPatient=Visibility.Collapsed;
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
        public ObservableCollection<Medecin> Medecins { get; set; }




        #endregion


        #region partie Rendez-Vous
        public RDV Rdv { get => rdv; set => rdv = value; }
        public DateTime DateRDV { get => Rdv.DateRDV; set => Rdv.DateRDV = value; }

        #endregion

        public Specialite SPE { get => spe; set => spe = value; }
        public ObservableCollection<Specialite> Specialites { get; set; }



        
        public Visibility VisibilityPatient { get => visibilityPatient; set { visibilityPatient = value; RaisePropertyChanged(); } }
        public Visibility VisibilityMedecin { get => visibilityMedecin; set { visibilityMedecin = value; RaisePropertyChanged(); } }
        public Visibility VisibilityRDV { get => visibilityRDV; set { visibilityRDV = value; RaisePropertyChanged(); } }
        public ICommand AjoutPatientCommand { get; set; }

        public ICommand RecherchePatientCommand { get; set; }

        public ICommand MenuPatientCommand { get; set; }
        public ICommand MenuMedecinCommand { get; set; }
        public ICommand MenuRDVCommand { get; set; }
        public MainViewModel()
        {
            Patient = new Patient();
            Medecin = new Medecin();
            Rdv = new RDV();
            SPE = new Specialite();

            AjoutPatientCommand = new RelayCommand(ActionAjoutPatientCommand);
            RecherchePatientCommand = new RelayCommand(ActionRecherchePatientCommand);
            Patients = new ObservableCollection<Patient>(Patient.GetPatients());
            MenuPatientCommand = new RelayCommand(ActionMenuPatientCommand);
            MenuMedecinCommand = new RelayCommand(ActionMenuMedecinCommand);
            MenuRDVCommand = new RelayCommand(ActionMenuRDVCommand);
            DateNaissance = DateTime.Now;
            DateEmbauche = DateTime.Now;
            Specialites = new ObservableCollection<Specialite>(Specialite.GetListSpecialite());

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
            if (CodePatient > 0)
            {
                Patient = Patient.GetPatientById(CodePatient);
                RaiseAllChangedPatient();
            }
            else
                MessageBox.Show("Veuillez saisir d'abord le code patient à chercher !", "erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);

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

        }



    }
}
