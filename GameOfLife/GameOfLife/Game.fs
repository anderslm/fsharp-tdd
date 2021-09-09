module GameOfLife.Game

type Position =
    { X : int
      Y : int }

type Cell =
    | Living of Position
    | Dead  of Position

let CreateLivingCell position =
    Living position
    
let CreateDeadCell (position : Position) =
    Dead position
    
let NumberOfNeighbours game (position : Position) =
    let isAdjacent pos1 pos2 =
        pos1.X = pos2.X
        
    let cell =
        game
        |> List.find (function
            | Living p -> p.X = position.X && p.Y = position.Y
            | Dead p -> p.X = position.X && p.Y = position.Y)
        |> List.map (function
            | Living p -> p
            | Dead p -> p)
    game
    |> List.filter (function
            | Living p -> isAdjacent p cell
            | Dead p -> p.X = position.X && p.Y = position.Y)
    
let Start (initialCells : Cell list) =
    initialCells