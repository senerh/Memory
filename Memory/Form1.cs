using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dllLoto;

namespace Memory
{
    public partial class memory : Form
    {
        // Déclaration des variables globales du jeu
        int nbCartesDansSabot;  // Nombre de cartes dans le sabot (en fait nombre
        // d'images dans le réservoir)
        int nbCartesSurTapis;   // Nombre de cartes sur le tapis
        int[] cartesTiree;

        private void Distribution_Aleatoire()
        {
            cartesTiree = new int[nbCartesSurTapis];
            // On utilise la LotoMachine pour générer une série aléatoire
            LotoMachine hasard = new LotoMachine(nbCartesDansSabot);
            // On veut une série de nbCartesSurTapis cartes parmi celles 
            // du réservoir
            int[] tImagesCartes = hasard.TirageAleatoire(nbCartesSurTapis, false);
            // La série d'entiers retournée par la LotoMachine correspondra
            // aux indices des cartes dans le "sabot"

            // Affectation des images aux picturebox
            PictureBox carte;
            int i_image;
            for (int i_carte = 0; i_carte < nbCartesSurTapis; i_carte++)
            {
                carte = (PictureBox)tlpTapisDeCartes.Controls[i_carte];
                i_image = tImagesCartes[i_carte + 1]; // i_carte + 1 à cause
                // des pbs d'indices
                cartesTiree[i_carte] = i_image;
                carte.Image = ilSabotDeCartes.Images[i_image];
            }
        }

        private void Retournement()
        {
            PictureBox carte;
            foreach (Control ctrl in tlpTapisDeCartes.Controls)
            {
                // Je sais que le contrôle est une PictureBox
                // donc je "caste" l'objet (le Contrôle) en PictureBox...
                carte = (PictureBox)ctrl;
                // Ensuite je peux accéder à la propriété Image
                // (je ne pourrais pas si je n'avais pas "casté" le contrôle)
                carte.Image = ilSabotDeCartes.Images[0];
            }
        }

       
        

        public memory()
        {
            InitializeComponent();
        }

        private void Distribution_Sequentielle()
        {
            PictureBox carte;
            int i_carte = 1;

            foreach (Control ctrl in tlpTapisDeCartes.Controls)
            {
                // Je sais que le contrôle est une PictureBox
                // donc je "caste" l'objet (le Contrôle) en PictureBox...
                carte = (PictureBox)ctrl;
                // Ensuite je peux accéder à la propriété Image
                // (je ne pourrais pas si je n'avais pas "casté" le contrôle)
                carte.Image = ilSabotDeCartes.Images[i_carte];
                i_carte++;
            }
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Distribuer_Click(object sender, EventArgs e)
        {
            // On récupère le nombre d'images dans le réservoir :
            nbCartesDansSabot = ilSabotDeCartes.Images.Count - 1;
            // On enlève 1 car :
            // -> la l'image 0 ne compte pas c’est l’image du dos de carte 
            // -> les indices vont de 0 à N-1, donc les indices vont jusqu’à 39
            //    s’il y a 40 images au total *

            // On récupère également le nombre de cartes à distribuées sur la tapis
            // autrement dit le nombre de contrôles présents sur le conteneur
            nbCartesSurTapis = tlpTapisDeCartes.Controls.Count;

            // On effectue la distribution (aléatoire) proprement dite
            Distribution_Aleatoire();
        }

        private void memory_Load(object sender, EventArgs e)
        {

        }

        private void btn_Retourner_Click(object sender, EventArgs e)
        {
            Retournement();
        }

        private void btn_Jouer_Click(object sender, EventArgs e)
        {
            LotoMachine hasard = new LotoMachine(nbCartesSurTapis);
            int[] tImagesCartes = hasard.TirageAleatoire(nbCartesSurTapis, false);
            int i = hasard.NumeroAleatoire();
            switch(i)
            {
                case 1 : 
                    pb_Recherche.Image = ilSabotDeCartes.Images[cartesTiree[0]];
                    break;
                case 2 :
                    pb_Recherche.Image = ilSabotDeCartes.Images[cartesTiree[1]];
                    break;
                case 3 :
                    pb_Recherche.Image = ilSabotDeCartes.Images[cartesTiree[2]];
                    break;
                case 4 :
                    pb_Recherche.Image = ilSabotDeCartes.Images[cartesTiree[3]];
                    break;
            }
             

            Retournement();
          
        }
    }
}
