using Model;

namespace _Scripts.Controller {
    public class BulletController : Bullet {

        public bool RicochetDecrement() {
            return --ricochetCount > 0;
        }
    }
}
