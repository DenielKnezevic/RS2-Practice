using AutoMapper;
using RS2_Vjezba.Services.Database;
using RS2_Vjezbe.Models;
using RS2_Vjezbe.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace RS2_Vjezba.Services.Services
{
    public class KorisnikService : CRUDService<RS2_Vjezbe.Models.Korisnici,Database.Korisnici, RS2_Vjezbe.Models.KorisniciSearchObject , KorisniciInsertRequest , KorisniciUpdateRequest>, IKorisnikService
    {

        public KorisnikService(eProdajaContext context , IMapper mapper)
            : base(context ,mapper)
        {
        }

        public override RS2_Vjezbe.Models.Korisnici Insert(KorisniciInsertRequest insert)
        {
            if (insert.Password != insert.PasswordConfirmation)
                throw new UserException("Password and confirmation are not equal");

            var entity = base.Insert(insert);

            foreach (var uloga in insert.UlogeID)
            {
                Database.KorisniciUloge uloge = new Database.KorisniciUloge();
                uloge.KorisnikId = entity.KorisnikId;
                uloge.UlogaId = uloga;
                uloge.DatumIzmjene = DateTime.Now;

                Context.KorisniciUloges.Add(uloge);
            }

            Context.SaveChanges();
            return entity;
        }

        public override IQueryable<Database.Korisnici> AddFilter(IQueryable<Database.Korisnici> query, KorisniciSearchObject search = null)
        {
            if (!string.IsNullOrEmpty(search.Ime))
            {

                query = query.Where(x => x.Ime.Contains(search.Ime));
            }

            if (!string.IsNullOrEmpty(search.Username))
            {

                query = query.Where(x => x.Prezime.Contains(search.Username));
            }

            return query;
        }

        public override IQueryable<Database.Korisnici> AddInclude(IQueryable<Database.Korisnici> query, KorisniciSearchObject search = null)
        {
            if (search?.IncludeRoles == true)
            {
                query = query.Include("KorisniciUloges.Uloga");
            }

            return query;
        }


        public override void BeforeInsert(KorisniciInsertRequest insert, Database.Korisnici entity)
        {
            var salt = GenerateSalt();
            var hash = GenerateHash(salt, insert.Password);
            entity.LozinkaHash = hash;
            entity.LozinkaSalt = salt;
            base.BeforeInsert(insert, entity);
        }

        public RS2_Vjezbe.Models.Korisnici Login(string username , string password)
        {
            var user = Context.Korisnicis.Include("KorisniciUloges.Uloga").FirstOrDefault(x => x.KorisnickoIme == username);

            if (user == null) { return null; }

            var hash = GenerateHash(user.LozinkaSalt, password);

            if(user.LozinkaHash != hash) { return null; }

            return _mapper.Map<RS2_Vjezbe.Models.Korisnici>(user);
        }

        public static string GenerateSalt()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[16];
            provider.GetBytes(byteArray);


            return Convert.ToBase64String(byteArray);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
    }
}
