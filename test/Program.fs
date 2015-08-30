(*
** Emulated GLES2 for .Net
** Copyright (C) 2015  Wael El Oraiby
** 
** This program is free software: you can redistribute it and/or modify
** it under the terms of the GNU Affero General Public License as
** published by the Free Software Foundation, either version 3 of the
** License, or (at your option) any later version.
** 
** This program is distributed in the hope that it will be useful,
** but WITHOUT ANY WARRANTY; without even the implied warranty of
** MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
** GNU Affero General Public License for more details.
** 
** You should have received a copy of the GNU Affero General Public License
** along with this program.  If not, see <http://www.gnu.org/licenses/>.
*)
open Render

[<EntryPoint>]
let main argv = 

    printfn "init: %d" (Glfw3.init())
    printfn "version: %A" (Glfw3.getVersion())
    printfn "str version: %s" (Glfw3.getVersionString())
    printfn "monitors: %d" (Glfw3.getMonitors().Length)

    let primaryMonitor = Glfw3.getPrimaryMonitor()

    printfn "primary monitor position: %A" (Glfw3.getMonitorPos(primaryMonitor))

    Glfw3.getMonitors()
    |> Array.iter (fun m -> printfn "Pos: %A\nSize: %A" (Glfw3.getMonitorPos m) (Glfw3.getMonitorPhysicalSize m))

    printfn "%A" argv
    0 // return an integer exit code
