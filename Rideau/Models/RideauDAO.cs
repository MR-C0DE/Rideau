using Rideau.Data;
using Microsoft.EntityFrameworkCore;

namespace Rideau.Models
{
    public class RideauDAO
    {
        //Declaration de la base de donnee
        private RideauContext? database;

        public RideauDAO()
        {
            // Initialisation de la base de donnée 
            database = null;
        }
        public RideauContext? Database { get => database; set => database = value; }

        public Task<List<LivreVO>>? GetLivre()
        {
            return database.LivreVO.ToListAsync();
        }
        public Task<LivreVO?>? GetLivreByID(int? id)
        {
           
            return database.LivreVO.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async void AddLivre(LivreVO livreVO)
        {
            database.Add(livreVO);

        }

        public async void SetLivre(LivreVO livreVO)
        {
            database.Update(livreVO);
        }

        public void UpdateLivre(LivreVO livreVO)
        {
            database.Update(livreVO);

        }

        public ValueTask<LivreVO?> FindLivreById(int ? id)
        {
            return database.LivreVO.FindAsync(id);
        }

        public void SupprimeLivre(LivreVO livreVO)
        {
            database.Remove(livreVO);
        }

        public bool LivreExiste(int ? id)
        {
            return database.LivreVO.Any(e => e.Id == id);
        }



        // TRAITEMENT DU CLIENT
        public Task<List<ClientVO>>? GetClient()
        {
            return database.ClientVO.ToListAsync();
        }
        public Task<ClientVO?>? GetClientByID(int? id)
        {
            return database.ClientVO.FirstOrDefaultAsync(m => m.Id == id);
        }

        public int CountClient()
        {
            var data = database.ClientVO.Count();
            return data;
        }

        public async void AddClient(ClientVO clientVO)
        {

            database.Add(clientVO);

        }

        public async void SetClient(ClientVO clientVO)
        {
            database.Update(clientVO);
        }

        public void UpdateClient(ClientVO clientVO)
        {
            database.Update(clientVO);

        }

        public ValueTask<ClientVO?> FindClientById(int? id)
        {
            return database.ClientVO.FindAsync(id);
        }

        public void SupprimeClient(ClientVO clientVO)
        {
            database.Remove(clientVO);
        }

        public bool ClientExiste(int? id)
        {
            return database.ClientVO.Any(e => e.Id == id);
        }


    }

}
