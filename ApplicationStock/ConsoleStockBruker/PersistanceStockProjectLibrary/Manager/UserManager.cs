using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectStockDTOS;
using AutoFixture;
using PersistanceStockProjectLibrary.Interfaces;

namespace PersistanceStockProjectLibrary.Manager
{
    public class UserManager : IUserManager
    {
        private List<UserDto> users { get; set; } = new List<UserDto>();
        private readonly Fixture _fixture = new Fixture();
        /// <summary>
        /// Gets the creatures from the codex
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserDto> GetAllUsers()
        {
            var creatures = new List<Client>() { new Client() { _firstName = "test", _lastName = "test" ,_email = "test@test.fr" ,_phone =" 0600000000",_siret = "ttet"} };
        
            foreach (var creature in creatures)
            {
                users.Add(new UserDto() { _id = creature._id, _firstName = creature._firstName, _lastName = creature._lastName, _email = creature._email, _phone = creature._phone, _siret = creature._siret });
                yield return new UserDto() { _id = creature._id, _firstName = creature._firstName, _lastName = creature._lastName, _email = creature._email, _phone = creature._phone, _siret = creature._siret };
            }
        }
       
        public IEnumerable<Client> GetUsers()
        {

           return _fixture.CreateMany<Client>(20);
          
        }


        public UserDto GetUser(int id)
        {
            return users[id];
        }  


        public void Update(int id, UserDto userDto)
        {
            try
            {
                users[id] = userDto;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erreur update " +ex.ToString());
            }
            
        }


        public void Add(UserDto userDto)
        {

            try
            {
                users.Add(userDto);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erreur Add" + ex.ToString());
            }
           
        }


        public void Delete(UserDto userDto)
        {
            try
            {
                users.Remove(userDto);
            }
            catch(Exception ex)
            {
                throw new ArgumentException("Erreur delete" + ex.ToString());
            }
        }
    }
}