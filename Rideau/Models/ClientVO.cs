namespace Rideau.Models
{
    public class ClientVO
    {
        private int id;
        private int livre_id;
        private string prenom;
        private string nom;
        private string email;
        private string adresse;
        private string ville;
        private string codePostal;

        public ClientVO()
        {

        }


        public ClientVO(int id, int livre_id, string prenom, string nom, string email, string adresse, string ville, string codePostal)
        {
            this.id = id;
            this.livre_id = livre_id;
            this.prenom = prenom;
            this.nom = nom;
            this.email = email;
            this.adresse = adresse;
            this.ville = ville;
            this.codePostal = codePostal;
        }

        public int Id { get => id; set => id = value; }
        public int Livre_id { get => livre_id; set => livre_id = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Email { get => email; set => email = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string Ville { get => ville; set => ville = value; }
        public string CodePostal { get => codePostal; set => codePostal = value; }


    }
}
