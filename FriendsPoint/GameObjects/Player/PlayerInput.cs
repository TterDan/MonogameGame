namespace FriendsPoint.GameObjects.Player {
    public partial class Player : CircleHBoxObj {          // Класс игрока, наследует класс GameObject
        
        public void ShiftLook(bool ShiftPressed, Point mousePosition) {
            Vector2 mouseDirectionForCamera;
            if (ShiftPressed) {
                mouseDirectionForCamera = new Vector2(mousePosition.X - ScreenCenter.X, mousePosition.Y - ScreenCenter.Y);
                mouseDirectionForCamera.Normalize();
            } else {
                mouseDirectionForCamera = Vector2.Zero;
            }
            Camera.ChangeShiftOffset(mouseDirectionForCamera);
        }
        public void Rotate(Point mousePositionPoint, List<GameObject> weapons) {                           // Функция поворота игрока в сторону мыши
            mousePosition = new Vector2(mousePositionPoint.X, mousePositionPoint.Y);
            mouseDirection = new Vector2(mousePosition.X - ScreenPosition.X, mousePosition.Y - ScreenPosition.Y);
            Vector2 mouseDirectionNormalized = Vector2.Normalize(mouseDirection) * 500f;
            mouseDirectionForCamera = new Vector2(mousePosition.X - ScreenCenter.X, mousePosition.Y - ScreenCenter.Y) + mouseDirectionNormalized;
            Camera.ChangeMouseOffset(mouseDirectionForCamera);
            Rotation = (float)Math.Atan2(mouseDirection.Y, mouseDirection.X) + MathHelper.PiOver2;
            for (int i = 0; i < weapons.Count; i++)
            {
                Weapon weapon = (Weapon)weapons[i];
                if (weapon.Radius >= (weapon.ScreenPosition - mousePosition).Length())
                {
                    viewWeapon = weapon;
                    return;
                }
            }
            viewWeapon = null;
        }
        public void Move(Vector2 moveDirection, List<GameObject> players, List<GameObject> weapons, List<GameObject> enemies, List<GameObject> otherGameObjects, float deltaTime)   // Функция перемещения всех обьектов на карте
        {
            Vector2 targetVelocity = moveDirection * MoveSpeed;
            CurrentSpeed = Vector2.Lerp(CurrentSpeed, targetVelocity, 2f * deltaTime);
            Camera.ChangeWalkOffset(moveDirection);
            Position += CurrentSpeed * deltaTime;
        }
    }
}