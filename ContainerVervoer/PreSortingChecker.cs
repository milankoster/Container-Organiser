using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using ContainerVervoer.Exceptions;

namespace ContainerVervoer
{
    public static class PreSortingChecker
    {
        public static void ExecuteChecks(Ship ship, List<Container> containers, IConfiguration configuration)
        {
            int weight = containers.Sum(c => c.Weight);
            CheckMaxWeight(ship,weight);
            CheckMinWeight(ship,weight);
            CheckSpace(ship,containers);
            CheckVaCoSpaces(ship,containers);
            ValidateContainers(containers, configuration);
        }

        /// <summary>
        /// Checks if the containers are within this weight limits 
        /// </summary>
        private static void ValidateContainers(List<Container> containers, IConfiguration configuration)
        {
            var baseWeight = configuration.ContainerBaseWeight;
            var maxWeight = configuration.ContainerMaxWeight;
            
            foreach (Container container in containers)
            {
                ValidateContainer(container.Weight, baseWeight, maxWeight);
            }
        }
        
        private static void ValidateContainer(int weight, int baseWeight, int maxWeight)
        {
            if (weight < baseWeight)
                throw new InvalidContainerException($"Container is too light. Weight: {weight}. Base Weight {baseWeight}");
            if (weight > maxWeight)
                throw new InvalidContainerException($"Container is too heavy. Weight: {weight}. Max Weight {maxWeight}");
        }
        
        /// <summary>
        /// Checks if the containers weigh too much for the ship
        /// </summary>
        private static void CheckMaxWeight(Ship ship, int weight)
        {
            if (weight > ship.MaxWeight)
            {
                throw new InvalidWeightException("Containers weigh too much for the ship. " +
                                                 $"Container weight: {weight}. Maximum ship weight: {ship.MaxWeight}.");
            }
        }

        private static void CheckMinWeight(Ship ship, int weight)
        {
            if (weight < ship.MinWeight)
            {
                throw new InvalidWeightException("Containers weigh too little. " +
                                                 $"Container weight: {weight}. Minimum ship weight: {ship.MinWeight}.");
            }
        }

        /// <summary>
        /// Check if the ship has enough space to hold all valuable containers
        /// </summary>
        private static void CheckSpace(Ship ship, List<Container> containers)
        {
            int valuableSpaces = ContainerCrane.GetEligiblePlaces(ship, ContainerType.Valuable).Sum(c => c.Stacks.Count);
            int vaCoCount = containers.Count(c => c.Type == ContainerType.VaCo);
            int valuableCount = containers.Count(c => c.Type == ContainerType.Valuable) + vaCoCount;
            
            if (valuableCount > valuableSpaces)
            {
                throw new NotEnoughSpaceException("Not all valuable containers can be placed on the ship. " +
                                                  $"Amount of containers: {valuableCount}. Spaces: {valuableSpaces}");
            }
        }

        private static void CheckVaCoSpaces(Ship ship, List<Container> containers)
        {
            int vaCoSpaces = ContainerCrane.GetEligiblePlaces(ship, ContainerType.VaCo).Sum(c => c.Stacks.Count); 
            int vaCoContainersCount = containers.Count(c => c.Type == ContainerType.VaCo);
            if (vaCoContainersCount > vaCoSpaces)
            {
                throw new NotEnoughSpaceException("Not all valuable+cooled containers can be placed on the ship. " +
                                                  $"Amount of containers: {vaCoContainersCount}. Spaces: {vaCoSpaces}");
            }
        }
    }
}