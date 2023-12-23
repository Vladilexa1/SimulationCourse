using SimulationCourse.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationCourse
{
    public class Actions
    {
        public void InitActions(Map map)
        {
            MapConsoleRenderer mapConsoleRenderer = new MapConsoleRenderer();
            mapConsoleRenderer.SetBorderMap(new Rock());

            for (int i = 0; i < 100; i++)
            {
                map.EntitySetup(new Rock());
            }
            for (int i = 0; i < 100; i++)
            {
                map.EntitySetup(new Grass() { coordinates = new Coordinates(6, 8) });
            }
            for (int i = 0; i < 10; i++)
            {
                map.EntitySetup(new Herbivore() { coordinates = new Coordinates(5, 5) });
            }
            mapConsoleRenderer.Renderer(map);
        }
        public void MM(Map map)
        {
            foreach (var item in map.Maps.ToList())
            {
                MapConsoleRenderer mapConsoleRenderer = new MapConsoleRenderer();
                if (item.Value is Herbivore herbivore)
                {
                    map.DeleteEntitys(item.Value.coordinates);
                    mapConsoleRenderer.DeleteEntitys(item.Value.coordinates);
                    map.NewEntitySetup(herbivore.MakeMove(map));
                    mapConsoleRenderer.RenderOneEntity(item.Value);
                }
            }
           
            
        }
       
    }
}
