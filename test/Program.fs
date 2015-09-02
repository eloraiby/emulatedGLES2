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

    let monitors = Glfw3.getMonitors()
    printfn "monitors: %d" (monitors.Length)

    let primaryMonitor = Glfw3.getPrimaryMonitor()

    printfn "primary monitor position: %A" (Glfw3.getMonitorPos(primaryMonitor))

    monitors
    |> Array.iter (fun m -> printfn "Name: %s, Pos: %A, Size: %A" (Glfw3.getMonitorName m) (Glfw3.getMonitorPos m) (Glfw3.getMonitorPhysicalSize m))

    monitors
    |> Array.iteri
        (fun im m ->
            m
            |> Glfw3.getVideoModes
            |> Array.iteri
                (fun iv vm ->
                    printfn "%dx%d - width:  %d - height: %d - RGB:    %d%d%d - rate:   %d" im iv vm.width vm.height vm.redBits vm.greenBits vm.blueBits vm.refreshRate))

    let vm = Glfw3.getVideoMode primaryMonitor
    printfn "Primary: width:  %d - height: %d - RGB:    %d%d%d - rate:   %d" vm.width vm.height vm.redBits vm.greenBits vm.blueBits vm.refreshRate    

    //Glfw3.setGamma(primaryMonitor, 1.0f)

    let gammaRamp = Glfw3.getGammaramp(primaryMonitor)

    gammaRamp.Red |> Array.iter(fun r -> printfn "r: %d" r)

    let win = Glfw3.createWindow(640, 480, "Hello World", None, None)

    Glfw3.setWindowTitle(win, "Hahaha")
    Glfw3.setWindowPos(win, 100, 120)
    Glfw3.setWindowSize(win, 512, 512)

    printfn "Framebuffer %A" (Glfw3.getFrameBufferSize win)
    printfn "Window Frame size %A" (Glfw3.getWindowFrameSize win)

    let rec loop () =
        if Glfw3.windowShouldClose win
        then ()
        else
            Glfw3.pollEvents ()
            loop ()

    loop ()
    printfn "Pos : %A" (Glfw3.getWindowPos win)
    printfn "Size: %A" (Glfw3.getWindowSize win)

    0 // return an integer exit code
