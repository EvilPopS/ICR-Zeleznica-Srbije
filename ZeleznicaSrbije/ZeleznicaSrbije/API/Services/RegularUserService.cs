using ZeleznicaSrbije.API.CRUD;

namespace ZeleznicaSrbije.API.Services {
    public class RegularUserService {
        private readonly RegularUserCRUD _userCRUD;

        public RegularUserService() {
            _userCRUD = new RegularUserCRUD();
        }


    }
}
