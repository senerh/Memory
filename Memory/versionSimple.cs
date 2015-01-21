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
        int nb_cartes;
        int Image_1;
        int Image_2;
        int score = 0;

        
        public memory()
        {
            InitializeComponent();
        }

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
                carte.Update();
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
            pb_Recherche.Image = ilSabotDeCartes.Images[0];
            nb_cartes = 0;
        }

        private void btn_Retourner_Click(object sender, EventArgs e)
        {
            Retournement();
        }

        private void btn_Jouer_Click(object sender, EventArgs e)
        {
            MessageBox.Show("vous avez 3 sec pour voir les images");
            btn_Distribuer_Click(sender, e);
           
            System.Threading.Thread.Sleep(3000);
            LotoMachine hasard = new LotoMachine(nbCartesSurTapis);
            int[] tImagesCartes = hasard.TirageAleatoire(nbCartesSurTapis, false);
            int i = hasard.NumeroAleatoire();
            switch(i)
            {
                case 1 :
                    pb_Recherche.Image = ilSabotDeCartes.Images[cartesTiree[0]];
                    pb_Recherche.Image.Tag = cartesTiree[0];

                    break;
                case 2 :
                    pb_Recherche.Image = ilSabotDeCartes.Images[cartesTiree[1]];
                    pb_Recherche.Image.Tag = cartesTiree[1];

                    break;
                case 3 :
                    pb_Recherche.Image = ilSabotDeCartes.Images[cartesTiree[2]];
                    pb_Recherche.Image.Tag = cartesTiree[2];

                    break;
                case 4 :
                    pb_Recherche.Image = ilSabotDeCartes.Images[cartesTiree[3]];
                    pb_Recherche.Image.Tag = cartesTiree[3];

                    break;
                case 5:
                    pb_Recherche.Image = ilSabotDeCartes.Images[cartesTiree[4]];
                    pb_Recherche.Image.Tag = cartesTiree[4];

                    break;
                case 6:
                    pb_Recherche.Image = ilSabotDeCartes.Images[cartesTiree[5]];
                    pb_Recherche.Image.Tag = cartesTiree[5];

                    break;
                case 7:
                    pb_Recherche.Image = ilSabotDeCartes.Images[cartesTiree[6]];
                    pb_Recherche.Image.Tag = cartesTiree[6];

                    break;
                case 8:
                    pb_Recherche.Image = ilSabotDeCartes.Images[cartesTiree[7]];
                    pb_Recherche.Image.Tag = cartesTiree[7];
                    break;
            }
            
            Image_1 = (int)pb_Recherche.Image.Tag;
            nb_cartes = 1;
            Retournement();

        }

        private void pb_XX_Click(object sender, EventArgs e,int i_image)
        {
            PictureBox carte;
            int i_carte;

            if (nb_cartes < 2)
            {
                carte = (PictureBox)sender;
                i_carte = Convert.ToInt32(carte.Tag);
                //i_image = cartesTiree[i_carte];
                carte.Image = ilSabotDeCartes.Images[cartesTiree[i_image]];
                carte.Image.Tag = cartesTiree[i_image];
                if (nb_cartes == 0)
                {
                    Image_1 = (int)carte.Image.Tag;
                }
                if (nb_cartes == 1)
                {
                    Image_2 = (int)carte.Image.Tag;
                }
                nb_cartes++;
                if (Image_1 == Image_2)
                {
                    MessageBox.Show("Bravo ! On recommence!");
                    score += 10;
                    btn_Jouer_Click(sender, e);
                    /*menu menu = new menu();
                    menu.Show();
                    this.Close();*/
                }
                else
                {
                    MessageBox.Show("DOMMAGE !");
                    Retournement();
                    nb_cartes = 1;
                    Image_2 = -1;
                    score -= 2;
                }

            }
            else
            {
                MessageBox.Show("Vous avez gagné! on recommence");
                nb_cartes = 1;
                //Image_1 = null;
                Image_2 = -1;
                Retournement();
            }
            textBox1_TextChanged(sender, e);
        }
        

        private void pb_01_Click(object sender, EventArgs e)
        {
            pb_XX_Click(sender, e, 0);

        }

        private void pb_02_Click(object sender, EventArgs e)
        {
            pb_XX_Click(sender, e, 1);
        }

        private void pb_03_Click(object sender, EventArgs e)
        {
            pb_XX_Click(sender, e, 2);
        }

        private void pb_04_Click(object sender, EventArgs e)
        {
            pb_XX_Click(sender, e, 3);
        }

        private void pb_05_Click(object sender, EventArgs e)
        {
            pb_XX_Click(sender, e, 4);
        }

        private void pb_06_Click(object sender, EventArgs e)
        {
            pb_XX_Click(sender, e, 5);
        }

        private void pb_07_Click(object sender, EventArgs e)
        {
            pb_XX_Click(sender, e, 6);
        }

        private void pb_08_Click(object sender, EventArgs e)
        {
            pb_XX_Click(sender, e, 7);
        }

        public memory(FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = score.ToString();
        }
    }
}
