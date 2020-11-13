using System;
using System.Collections.Generic;
using System.Linq;

namespace ContainerVervoer
{
    public static class ContainerCrane
    {
        public static void Sort(Ship ship, List<Container> containers)
        {
            List<Container> valuableCooledContainers = GetAllOfType(containers, ContainerType.VaCo);
            SortContainers(ship, valuableCooledContainers, ContainerType.VaCo);
        }

        private static void SortContainers(Ship ship, List<Container> containers, ContainerType type)
        {
            containers = containers.OrderByDescending(c => c.Weight).ToList();
            Column[] eligiblePlaces = GetEligiblePlaces(ship, containers.First().Type);
            foreach (var container in containers)
            {
                PlaceContainer(ship, eligiblePlaces, container); //should place the container
            }
        }

        private static void PlaceContainer(Ship ship, Column[] eligiblePlaces, Container container)
        {
            if (ship.GetLeftSideWeight() >= ship.GetRightSideWeight())
                PlaceRightToLeft(ship, eligiblePlaces, container);
            else 
                PlaceLeftToRight(ship, eligiblePlaces, container);
        }

        private static void PlaceLeftToRight(Ship ship, Column[] eligiblePlaces, Container container)
        {
            var bestStack = CheckLeftSide(ship, eligiblePlaces, container);

            if (ship.Width % 2 == 1 && (ship.IsBalanced() || bestStack == null))
                bestStack = CheckMiddleStack(ship, eligiblePlaces, container, bestStack);
            
            if (bestStack == null)
                bestStack = CheckRightSide(ship, eligiblePlaces, container);
            
            if (bestStack == null)
                throw new NotImplementedException(); //TODO Throw proper error

            bestStack.Add(container);
        }
        
        private static void PlaceRightToLeft(Ship ship, Column[] eligiblePlaces, Container container)
        {
            Stack bestStack = CheckRightSide(ship, eligiblePlaces, container);

            if (ship.Width % 2 == 1 && (ship.IsBalanced() || bestStack == null))
                bestStack = CheckMiddleStack(ship, eligiblePlaces, container, bestStack);

            if (bestStack == null)
                bestStack = CheckLeftSide(ship, eligiblePlaces, container);
            
            if (bestStack == null)
                throw new NotImplementedException(); //TODO Throw proper error

            bestStack.Add(container);
        }

        private static Stack CheckMiddleStack(Ship ship, Column[] eligiblePlaces, Container container, Stack bestStack)
        {
            int middle = Convert.ToInt32(Math.Floor(ship.Width / 2.0));
            bestStack = CheckForBetterStack(eligiblePlaces, middle, container, bestStack);
            return bestStack;
        }

        private static Stack CheckRightSide(Ship ship, Column[] eligiblePlaces, Container container)
        {
            Stack bestStack = null;
            int minimum = Convert.ToInt32(Math.Ceiling(ship.Width / 2.0));
            for (int i = minimum; i < ship.Width; i++)
            {
                bestStack = CheckForBetterStack(eligiblePlaces, i, container, bestStack);
            }

            return bestStack;
        }

        private static Stack CheckLeftSide(Ship ship, Column[] eligiblePlaces, Container container)
        {
            Stack bestStack = null;
            for (int i = 0; i < Math.Floor(ship.Width / 2.0); i++)
            {
                bestStack = CheckForBetterStack(eligiblePlaces, i, container, bestStack);
            }
            return bestStack;
        }


        private static Stack CheckForBetterStack(Column[] eligiblePlaces, int i, Container container, Stack bestStack)
        {
            foreach (var stack in eligiblePlaces[i].GetStacks())
            {
                if (stack.GetTopWeight() + container.Weight > 120000) //TODO Magic Number
                    continue;
                if ((container.Type == ContainerType.Valuable || container.Type == ContainerType.VaCo) &&
                    stack.HasValuable())
                    continue;
                if (bestStack == null || bestStack.GetSize() > stack.GetSize())
                    bestStack = stack;
            }
            return bestStack;
        }

        private static List<Container> GetAllOfType(List<Container> containers, ContainerType type)
        {
            return containers.Where(x => x.Type == type).ToList();
        }

        private static Column[] GetEligiblePlaces(Ship ship, ContainerType type)
        {
            if (type == ContainerType.Normal)
                return ship.GetColumns();
            if (type == ContainerType.Cooled)
                return ship.GetColumns().Select(x => new Column(new[] {x.GetStacks().First()})).ToArray();
            if (type == ContainerType.VaCo)
                return ship.GetColumns().Select(x => new Column(new[] {x.GetStacks().First()})).ToArray();
            if (type == ContainerType.Valuable && ship.Length == 1)
                return ship.GetColumns().Select(x => new Column(new[] {x.GetStacks().First()})).ToArray();
            if (type == ContainerType.Valuable)
                return ship.GetColumns().Select(x => new Column(
                    new[] {x.GetStacks().First(), x.GetStacks().Last()})).ToArray();

            throw new ArgumentOutOfRangeException(nameof(type), type, "Container type not configured");
        }
    }
}