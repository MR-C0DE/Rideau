namespace Rideau.Models
{
    public class LivreVO
    {
        private int id;
        private string titre;
        private string auteur;
        private string description;
        private string edition;
        private string datePuplication;

        public LivreVO()
        {
            id = 0;
            titre = "inconnu";
            auteur = "inconnu";
            description = "inconnu";
            edition = "inconnu";
            datePuplication = "inconnu";
        }

        public LivreVO(int id, string titre, string auteur, string description, string edition, string datePuplication)
        {
            this.id = id;
            this.titre = titre;
            this.auteur = auteur;
            this.description = description;
            this.edition = edition;
            this.datePuplication = datePuplication;
        }

        public int Id { get => id; set => id = value; }
        public string Titre { get => titre; set => titre = value; }
        public string Auteur { get => auteur; set => auteur = value; }
        public string Description { get => description; set => description = value; }
        public string Edition { get => edition; set => edition = value; }
        public string DatePuplication { get => datePuplication; set => datePuplication = value; }
    }
}
