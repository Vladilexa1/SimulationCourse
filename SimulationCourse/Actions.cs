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
                map.EntitySetup(new Grass());
            }
            for (int i = 0; i < 10; i++)
            {
                map.EntitySetup(new Herbivore());
            }
            for (int i = 0; i < 10; i++)
            {
                map.EntitySetup(new Predator());
            }
            mapConsoleRenderer.Renderer(map);
        }
        public void TurnActions(Map map)
        {
            MapConsoleRenderer mapConsoleRenderer = new MapConsoleRenderer();
            foreach (var item in map.GetAllHerbivore())
            {
                map.DeleteEntitys(item.coordinates);
                mapConsoleRenderer.DeleteEntitys(item.coordinates);
                map.EntitySetup((item as Herbivore).MakeMove(map));
                mapConsoleRenderer.RenderOneEntity(item);
            }
            foreach (var item in map.GetAllPredator())
            {
                map.DeleteEntitys(item.coordinates);
                mapConsoleRenderer.DeleteEntitys(item.coordinates);
                map.EntitySetup((item as Predator).MakeMove(map));
                mapConsoleRenderer.RenderOneEntity(item);
            }
            AddGrass(map);
            AddHerbivore(map);
        }
        public void AddGrass(Map map)
        {
            MapConsoleRenderer mapConsoleRenderer = new MapConsoleRenderer();
            if (Simulation.countGrass < 10)
            {
                for (int i = 0; i < 100; i++)
                {
                    Grass grass = new Grass();
                    map.EntitySetup(grass);
                    mapConsoleRenderer.RenderOneEntity(grass);
                }
            }
        }
        public void AddHerbivore(Map map) 
        {
            MapConsoleRenderer mapConsoleRenderer = new MapConsoleRenderer();
            if (Simulation.countHerbivore < 3)
            {
                for (int i = 0; i < 10; i++)
                {
                    Herbivore herbivore = new Herbivore();
                    map.EntitySetup(herbivore);
                    mapConsoleRenderer.RenderOneEntity(herbivore);
                }
            }
        }
    }
}
