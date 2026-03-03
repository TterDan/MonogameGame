namespace FriendsPoint.GameObjects.Player {
    public partial class Player : CircleHBoxObj {          // Класс игрока, наследует класс GameObject
        public override void Draw(SpriteBatch spriteBatch) {
            DrawEngine.Circle(spriteBatch, CircleTexture, ScreenPosition, Radius, Color.Black, 0.34f, 0f, 1f / (300 / Radius));
            DrawEngine.Circle(spriteBatch, CircleTexture, ScreenPosition, AdditionRadius, Color.Black * 0.65f, 0.05f, 0f, 1f / (300 / AdditionRadius));

            DrawEngine.DrawTexture(spriteBatch, ScreenPosition, Texture, Rotation, 0.7f, 0.42f);
            if (isShooting)
            {
                Vector2 recoilTarget = new Vector2(currentWeapon.RecoilStrength, 0f);
                recoilOffset = Vector2.Lerp(recoilOffset, recoilTarget, 1.5f * deltaTimeForRecoil);
            }
            if(!isShooting)
                recoilOffset = Vector2.Lerp(recoilOffset, Vector2.Zero, 0.3f * deltaTimeForRecoil);
            currentOffset = currentWeapon.HandleOffset + recoilOffset;
            Rectangle weaponRect = new Rectangle((int)ScreenPosition.X, (int)ScreenPosition.Y, currentWeapon.Radius * 2, currentWeapon.Radius * 2);
            Vector2 WeaponOffset1 = -new Vector2(currentOffset.X, currentOffset.Y);                              // Координаты для смещения оружия от игрока в его руке
            Vector2 WeaponOffset2 = -new Vector2(currentOffset.X, -currentOffset.Y);
            float fixedRotation = Rotation + MathF.PI / 2;
            float cosRotation = MathF.Cos(fixedRotation);
            float sinRotation = MathF.Sin(fixedRotation);
            Vector2 WeaponPos1 = new Vector2(cosRotation * WeaponOffset1.X - sinRotation * WeaponOffset1.Y, sinRotation * WeaponOffset1.X + cosRotation * WeaponOffset1.Y);      // Математика для определения смещения оружия от игрока в его руке
            Vector2 WeaponPos2 = new Vector2(cosRotation * WeaponOffset2.X - sinRotation * WeaponOffset2.Y, sinRotation * WeaponOffset2.X + cosRotation * WeaponOffset2.Y);      // Математика для определения смещения оружия от игрока в его руке

            if (currentWeapon.Name == "Fist") {
                DrawEngine.DrawTexture(spriteBatch, ScreenPosition + WeaponPos1, currentWeapon.Texture, Rotation, 1f, 0.35f);
                DrawEngine.DrawTexture(spriteBatch, ScreenPosition + WeaponPos2, currentWeapon.Texture, Rotation, 1f, 0.35f);
            } else {
              DrawEngine.DrawTexture(spriteBatch, ScreenPosition + WeaponPos1, currentWeapon.Texture, (Rotation) - MathF.PI / 2 + currentWeapon.TextureRotationInPlayerHand / 180 * MathF.PI, currentWeapon.TextureScale, 0.35f);
            }
            if (ShotDrawTimer <= currentShotDrawTime) {
                for (int i = 0; i < bullets.Count; i++)
                {
                    DrawEngine.Line(spriteBatch, ScreenPosition + GetTrunkOffset(), ScreenPosition + bullets[i], Color.Yellow, 4.5f, 1f);
                    Console.Log(rnd.Next(0, 10000), "1");
                }
            }
            Console.Log(currentShotDrawTime, "5959");
            Console.Log(ShotDrawTimer, "59159");
            if(currentWeapon.Type != "Melee")
                Main.CartrigesInMagazineUI(spriteBatch,currentWeapon.CartrigesInMagazine, currentWeapon.TotalCartriges);
            if (viewWeapon != null) {
                float minCord = MathF.Abs(mouseDirection.X) > MathF.Abs(mouseDirection.Y) ? mouseDirection.Y : mouseDirection.X;
                minCord = MathF.Abs(minCord);
                Vector2 firstPoint = ScreenPosition;
                Vector2 secondPoint = firstPoint + new Vector2(minCord * mouseDirection.X / Math.Abs(mouseDirection.X), minCord * mouseDirection.Y / Math.Abs(mouseDirection.Y));
                Vector2 thirdPoint = secondPoint + (mousePosition - secondPoint);

                if (AdditionRadius + viewWeapon.Radius >= (viewWeapon.ScreenPosition - ScreenPosition).Length() && viewWeapon.Name != "Cartriges") {
                    CanToTakeWeapon = true;
                    Main.ViewWeaponUI(spriteBatch, firstPoint, secondPoint, thirdPoint, viewWeapon.Name, Color.White);
                } else {
                    Main.ViewWeaponUI(spriteBatch, firstPoint, secondPoint, thirdPoint, viewWeapon.Name, Color.Gray);
                    CanToTakeWeapon = false;
                }
            } else {
                Main.CursorUI(spriteBatch, new Vector2(mousePosition.X - 33, mousePosition.Y - 26));
            }
        }
    }
}