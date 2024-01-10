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
        public void turnActions(Map map)
        {
            MapConsoleRenderer mapConsoleRenderer = new MapConsoleRenderer();
            foreach (var item in map.Maps.ToList())
            {
                if (item.Value is Herbivore herbivore)
                {
                    map.DeleteEntitys(item.Value.coordinates);
                    mapConsoleRenderer.DeleteEntitys(item.Value.coordinates);
                    map.NewEntitySetup(herbivore.MakeMove(map));
                    mapConsoleRenderer.RenderOneEntity(item.Value);
                }
                if (item.Value is Predator predator)
                {
                    map.DeleteEntitys(item.Value.coordinates);
                    mapConsoleRenderer.DeleteEntitys(item.Value.coordinates);
                    map.NewEntitySetup(predator.MakeMove(map));
                    mapConsoleRenderer.RenderOneEntity(item.Value);
                }
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
