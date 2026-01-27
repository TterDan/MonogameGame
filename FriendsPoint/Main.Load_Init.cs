using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Nodes;
using System.Threading;
using FriendsPoint.GameObjects;
namespace FriendsPoint
{
    public partial class Main           // Пишу именно partial class, чтобы соединить все файлы начинающиеся на Main в один класс
    {
        // Инициализация
        protected override void Initialize()
        {
            windowSize = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);                    // Получаю размеры окна
            render = new SpriteBatch(GraphicsDevice);      
            // Инициализирую спрайтбатч
            Texture2D fistTexture = Content.Load<Texture2D>("weapons/deagle");
            fist = new Weapon(GraphicsDevice, fistTexture, "Fist", "Melee", Vector2.Zero, 20, 50, new List<float> { 15, 0, 1, 3, 0, 300, 20, 0, 0, 0});

            player = new Player(GraphicsDevice, Vector2.Zero, 35, 60, 5, new Vector2(windowSize.X / 2 , windowSize.Y / 2), fist);     // Инициализирую игрока

            Texture2D line;
            line = new Texture2D(GraphicsDevice, 1, 1);
            line.SetData(new[] { Color.White });
            player.lineTexture = line;
            player.render = render;

            System.Diagnostics.Debug.WriteLine(windowSize);
            map = new Map(new Vector2(0, 0), 400, 400);                                                                 // Инициализирую карту
            objects = new List<GameObject>();                                                                           // Инициализирую список всех элементов
            droppedWeapons = new List<(Weapon, Vector2)>();
            debugPixel = new Texture2D(GraphicsDevice, 1, 1);
            debugPixel.SetData(new[] { Color.Red });                                                                    
            objects.Add(map);
            objects.Add(player);
            graphics.ApplyChanges();
            rnd = new System.Random();
            weaponsArray = JsonNode.Parse(File.ReadAllText("../../../WeaponData.json")).AsArray();
            for (int i = 0; i < 2; i++) {                                                                                // Добавляю несколько врагов на карту для теста
                Enemy enemy = new Enemy(
                    GraphicsDevice,
                    new Vector2(200 + i * 100, 200),
                    30,
                    3f
                );
                objects.Add(enemy);
            }
            for(int i = 0; i < 5; i++)
            {
                int rndWeapon = rnd.Next(0, weaponsArray.Count);
                System.Diagnostics.Debug.WriteLine(weaponsArray.Count);
                string pathToImg = weaponsArray[rndWeapon]["Path"].ToString();
                Texture2D weaponTexture = Content.Load<Texture2D>($"weapons/{pathToImg}");
                Weapon wpn = new Weapon(GraphicsDevice, weaponTexture, weaponsArray[rndWeapon]["Name"].ToString(), weaponsArray[rndWeapon]["Type"].ToString(), new Vector2(rnd.Next(-500, 500), rnd.Next(-500, 500)), 30, 50, new List<float> { 40, 15, 1, 3, 4000, 130, 20, 0, 15, 45 });
                objects.Add(wpn);
            }

            base.Initialize();
        }

        // Код загрузки моделей и контента
        protected override void LoadContent()
        {


            player.Texture = Content.Load<Texture2D>("players/soldierRF");          // Назначаю текстуру игрока
            map.Texture = Content.Load<Texture2D>("floor");                         // Назначаю текстуру карты
            font = Content.Load<SpriteFont>("DebugFont");                           // Назначаю шрифт для текста
        }
    }
}