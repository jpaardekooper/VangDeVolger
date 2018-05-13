
namespace VangDeVolgerSetup
{
    /// <summary>
    /// A SpriteObject with movement
    /// </summary>
    class Box : Sprite
    {
        /// <summary>
        /// This will create a new box depending o nthe parameter if it will be a (water sprite) that cannot move 
        /// or a wall sprite that can move and block an enemy
        /// generation is based in GenerateTile and Tile
        /// </summary>
        /// <param name="canMove"></param>
        public Box(bool canMove)
        {
            // sets attributes based on canMove : bool Pictures are stored in the Properties folder
            if (canMove)
            {
                SpriteImage = Properties.Resources.box;
                PushWall = true;
            }
            else
            {
                SpriteImage = Properties.Resources.wall1;
                PushWall = false;
            }

            ObjectGameBox = null;

            // set other class atributes
            CheckAlifeStatus = false;
            BlockEnemy = true;
        }

        /// <summary>
        /// Moves the box based on its neighbours
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="direction"></param>
        public override void Move(Tile tile, Tile.Neighbours direction)
        {
            // Local gamebox for use in the loop   
            Tile AnotherGameBoX = tile;

            // while the CheckAliveStatus is false we continue checking the neighbours and tiles
            while (CheckAlifeStatus == false)
            {
                if (!(AnotherGameBoX._HasNeighbours[direction]._HasNeighbours.ContainsKey(direction)))
                {
                    // Checks if the the tile after the first box exists
                    return;
                }

                if (!AnotherGameBoX._HasNeighbours[direction].SpriteObject.PushWall)
                {
                    // Prevents steel box pushing
                    return;
                }

                if (AnotherGameBoX._HasNeighbours[direction]._HasNeighbours[direction].SpriteObject is null)
                {
                    // If the the last position in the row is a box it will patch up the last object movement

                    // Moves the box before the last one to the last position
                    AnotherGameBoX._HasNeighbours[direction]._HasNeighbours[direction].SpriteObject = AnotherGameBoX._HasNeighbours[direction].SpriteObject;

                    // Moves the Hero to the next position
                    tile._HasNeighbours[direction].SpriteObject = tile.SpriteObject;

                    // Sets the Hero's origninal gamebox to null
                    tile.SpriteObject = null;

                    // Updates the Hero's gamebox
                    tile._HasNeighbours[direction].SpriteObject.ObjectGameBox = tile._HasNeighbours[direction];

                    // this ends the loop
                    break;
                }

                if (!AnotherGameBoX._HasNeighbours[direction]._HasNeighbours[direction].SpriteObject.PushWall)
                {
                    // Prevents water box pushing
                    return;
                }

                else if (AnotherGameBoX._HasNeighbours[direction]._HasNeighbours[direction].SpriteObject is Box)
                {
                    // If there is a box in the way it will update the GameBoxRecusie

                    // Checks if the move after the new box is possible,  otherwise it will stop the movement
                    if (!(AnotherGameBoX._HasNeighbours[direction]._HasNeighbours[direction]._HasNeighbours.ContainsKey(direction)))
                    {
                        return;
                    }

                    // Moves the box to its new position
                    AnotherGameBoX._HasNeighbours[direction]._HasNeighbours[direction].SpriteObject = AnotherGameBoX._HasNeighbours[direction].SpriteObject;

                    // Updates the AnotherGameBoX to the next one
                    AnotherGameBoX = AnotherGameBoX._HasNeighbours[direction];
                }
                else
                {
                    // if an object is discoverd with no relation to box moving, it will stop the movement
                    return;
                }
            }
        }
    }
}
