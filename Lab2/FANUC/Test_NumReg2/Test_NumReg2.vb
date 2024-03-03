﻿Option Explicit On
Imports System.Math

Public Class Test_NumReg2
    ' Sample VB.NET program to display R[1] and send a new value
    ' to/from any controller
    '
    ' Declarations
    '

    '   Public Class NumRegTest

    Private mobjRobot As FRRobot.FRCRobot
    Private WithEvents mobjRegs As FRRobot.FRCVars
    Dim Test1 As FRRobot.FRCVars



    ' Handle the Connect/Disconnect button click 
    Private Sub cmdConnect_Click(ByVal sender As Object, _
                                                             ByVal e As System.EventArgs) Handles cmdConnect.Click
        Try

            If cmdConnect.Text = "Connect" Then
                txtHostName.Text = "192.168.0.3"
                txtRegValue.Text = String.Format("Connecting to {0} Please wait.", txtHostName.Text)

                mobjRobot = New FRRobot.FRCRobot
                mobjRobot.Connect(txtHostName.Text) '%% you can write txtHostName.Text into the parantheses to define the ip address every time.
                mobjRegs = mobjRobot.RegNumerics

                ' modified DH angles in degrees
                Dim angleA(5), angleB(5), angleC(5), angleD(5) As Double
                Dim angle1Up(5), angle2Up(5), angle3Up(5), angle4Up(5) As Double
                Dim angle1Down(5), angle2Down(5), angle3Down(5), angle4Down(5) As Double
                Dim angle1fUp(5), angle2fUp(5), angle3fUp(5), angle4fUp(5) As Double
                Dim angle1fDown(5), angle2fDown(5), angle3fDown(5), angle4fDown(5) As Double
                Dim angle1hitUp(5), angle1hitDown(5) As Double


                angleA = invKin(435, -105, -80, 45)
                angleB = invKin(435, -105, -126, 45)
                'z = -210 for the dominos
                angleC = invKin(430, -100, -126, 45)
                'angleC = invKin(430, 100, -80, 90)
                angleD = invKin(430, 100, -80, 90)

                angle1Up = invKin(385, -105, -80, 45)
                angle1Down = invKin(385, -105, -210, 45)

                angle2Up = invKin(385, -5, -80, 135)
                angle2Down = invKin(385, -5, -210, 135)

                angle3Up = invKin(435, -105, -80, 135)
                angle3Down = invKin(435, -105, -210, 135)

                angle4Up = invKin(435, -5, -80, 45)
                angle4Down = invKin(435, -5, -210, 45)

                angle1fUp = invKin(500, -100, -80, 0)
                angle1fDown = invKin(500, -100, -210, 0)

                angle2fUp = invKin(500, -60, -80, 0)
                angle2fDown = invKin(500, -60, -210, 0)

                angle3fUp = invKin(500, -20, -80, 0)
                angle3fDown = invKin(500, -20, -210, 0)

                angle4fUp = invKin(500, 20, -80, 0)
                angle4fDown = invKin(500, 20, -210, 0)

                angle1hitUp = invKin(500, -140, -80, 0)
                angle1hitDown = invKin(500, -140, -210, 0)

                '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                'MAIN LOOP'
                '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

                ''%%%%%%%%%%%%
                ''Open Gripper
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then
                    mobjRobot.RegNumerics(1).Value.RegLong = 5
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If
                ''%%%%%%%%%%%%


                '' MOVE TO LINEAR COORDINATES
                'POINT 1 Up
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angle1Up)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                'POINT 1 Down
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angle1Down)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                ''%%%%%%%%%%%%
                ''Close Gripper
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then
                    mobjRobot.RegNumerics(1).Value.RegLong = 6
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If
                ''%%%%%%%%%%%%

                'POINT 1 Up
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angle1Up)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                'POINT 1f Up
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angle1fUp)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                'POINT 1f Down
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angle1fDown)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                ''%%%%%%%%%%%%
                ''Open Gripper
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then
                    mobjRobot.RegNumerics(1).Value.RegLong = 5
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If
                ''%%%%%%%%%%%%

                'POINT 1f Up
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angle1fUp)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                'POINT 2 Up
                '' MOVE TO LINEAR COORDINATES
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angle2Up)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                'POINT 2 Down
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angle2Down)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                ''%%%%%%%%%%%%
                ''Close Gripper
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then
                    mobjRobot.RegNumerics(1).Value.RegLong = 6
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If
                ''%%%%%%%%%%%%

                'POINT 2 Up
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angle2Up)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                'POINT 2f Up
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angle2fUp)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                'POINT 2f Down
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angle2fDown)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                ''%%%%%%%%%%%%
                ''Open Gripper
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then
                    mobjRobot.RegNumerics(1).Value.RegLong = 5
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If
                ''%%%%%%%%%%%%

                'POINT 2f Up
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angle2fUp)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                'POINT 3 Up
                '' MOVE TO LINEAR COORDINATES
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angle3Up)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                'POINT 3 Down
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angle3Down)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                ''%%%%%%%%%%%%
                ''Close Gripper
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then
                    mobjRobot.RegNumerics(1).Value.RegLong = 6
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If
                ''%%%%%%%%%%%%

                'POINT 3 Up
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angle3Up)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                'POINT 3f Up
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angle3fUp)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                'POINT 3f Down
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angle3fDown)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                ''%%%%%%%%%%%%
                ''Open Gripper
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then
                    mobjRobot.RegNumerics(1).Value.RegLong = 5
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If
                ''%%%%%%%%%%%%

                'POINT 3f Up
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angle3fUp)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                'POINT 4 Up
                '' MOVE TO LINEAR COORDINATES
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angle4Up)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                'POINT 4 Down
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angle4Down)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                ''%%%%%%%%%%%%
                ''Close Gripper
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then
                    mobjRobot.RegNumerics(1).Value.RegLong = 6
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If
                ''%%%%%%%%%%%%

                'POINT 4 Up
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angle4Up)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                'POINT 2f Up
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angle4fUp)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                'POINT 4f Down
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angle4fDown)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                ''%%%%%%%%%%%%
                ''Open Gripper
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then
                    mobjRobot.RegNumerics(1).Value.RegLong = 5
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If
                ''%%%%%%%%%%%%

                'POINT 4f Up
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angle4fUp)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                'POINT 1hit Up
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angle1hitUp)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                'POINT 1hit Down
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angle1hitDown)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                'HIT
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angle1fDown)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If


                ''HERE IS IN NOTEPAD SAHAND


                '' move to Home
                If mobjRobot.RegNumerics(2).value.reglong = 1 Then

                    mobjRobot.RegNumerics(1).value.reglong = 1
                    mobjRobot.RegNumerics(2).value.reglong = 0

                    While mobjRobot.RegNumerics(2).value.reglong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If





                '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                ''End the motion by setting R(1) to 99
                mobjRobot.RegNumerics(1).Value.RegLong = 1
                mobjRobot.RegNumerics(2).Value.RegLong = 0



                System.Threading.Thread.Sleep(2000)

                ''Zero the Register Values before disconnecting!
                'zeroRegs()




            Else    ' must be the user wants to disconnect

                txtRegValue.Text = "Releasing the Robot objects"
                ReleaseObjects()
                txtRegValue.Text = "Not Connected"
            End If

        Catch ex As System.Runtime.InteropServices.COMException
            ' The only time an error is expected is during connect
            MsgBox(String.Format("{0} - {1}", ex.ErrorCode, ex.Message))
            ReleaseObjects()
        Catch ex As Exception
            MsgBox(ex.Message)
            ReleaseObjects()
        End Try

        If mobjRobot IsNot Nothing AndAlso mobjRobot.IsConnected Then
            cmdConnect.Text = "Disconnect"
        Else
            cmdConnect.Text = "Connect"
        End If

    End Sub

    '
    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

    '' INVERSE KINEMATICS
    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%



    Public Function invKin(ByVal x As Double, ByVal y As Double, ByVal z As Double, ByVal alpha As Double)

        ' Put your inverse kinematics code here.
        ' Pi is declared as PI in the code.

        Dim l2, l3, l4 As Double
        l2 = 260
        l3 = Math.Sqrt(290 ^ 2 + 20 ^ 2)
        l4 = 78


        Dim th1, th2, th3, th4, th5, gm, xp, bt As Double

        th1 = Math.Atan2(y, x)
        xp = Math.Sqrt(x ^ 2 + y ^ 2)
        gm = Math.Atan2(z + l4, xp)
        bt = Math.Acos((l2 ^ 2 + xp ^ 2 + (z + l4) ^ 2 - l3 ^ 2) / (2 * l2 * Math.Sqrt(xp ^ 2 + (z + l4) ^ 2)))
        th2 = -1 * (gm + bt)
        th3 = -Math.Acos((xp ^ 2 + (z + l4) ^ 2 - l2 ^ 2 - l3 ^ 2) / (2 * l2 * l3))
        th4 = th2 - th3
        th5 = th1 - (alpha * PI / 180) + PI




        ' Fill outAngles(1) to outAngles(5) in degrees.

        Dim outAngles(5) As Double
        outAngles(1) = th1 * 180 / PI
        outAngles(2) = th2 * 180 / PI
        outAngles(3) = th3 * 180 / PI
        outAngles(4) = th4 * 180 / PI
        outAngles(5) = th5 * 180 / PI

        Return outAngles

    End Function




    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

    '' DH TO FANUC
    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    Public Function DH2Fanuc(ByVal DH() As Double)




        Dim outFanucAngles(5) As Double
        outFanucAngles(1) = DH(1)
        outFanucAngles(2) = DH(2) + 90
        outFanucAngles(3) = DH(3) - DH(2) - Math.Atan2(20, 290) * 180 / PI
        outFanucAngles(4) = DH(4) - 90 + Math.Atan2(20, 290) * 180 / PI
        outFanucAngles(5) = DH(5)

        Return outFanucAngles

    End Function

    Public Function ModifiedDH2Fanuc(ByVal DH() As Double)




        Dim outFanucAngles(5) As Double
        outFanucAngles(1) = DH(1)
        outFanucAngles(2) = DH(2) + 90
        outFanucAngles(3) = DH(3) - DH(2) - Math.Atan2(20, 290) * 180 / PI
        outFanucAngles(4) = DH(4) - 90 + Math.Atan2(20, 290) * 180 / PI
        outFanucAngles(5) = 90 - DH(5)

        Return outFanucAngles

    End Function















    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

    '' MOTION FUNCTIONS
    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

    '' LINEAR MOTION FUNCTION
    Private Sub moveLin(xLin As Double, yLin As Double, zLin As Double, wLin As Double, pLin As Double, rLin As Double, speedLin As Double)
        '' POINT1
        mobjRobot.RegNumerics(11).Value.RegLong = xLin     '' Point1 x-axis
        mobjRobot.RegNumerics(12).Value.RegLong = yLin     '' Point1 y-axis
        mobjRobot.RegNumerics(13).Value.RegLong = zLin     '' Point1 z-axis
        mobjRobot.RegNumerics(14).Value.RegLong = wLin     '' Point1 w-aangle
        mobjRobot.RegNumerics(15).Value.RegLong = pLin     '' Point1 p-angle
        mobjRobot.RegNumerics(16).Value.RegLong = rLin     '' Point1 r-angle
        '%%%%%%%%
        mobjRobot.RegNumerics(10).Value.RegLong = speedLin

    End Sub


    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    '' JOINT MOTION FUNCTION
    Private Sub moveJnt(theta1 As Double, theta2 As Double, theta3 As Double, theta4 As Double, theta5 As Double, speedJnt As Double)
        '' POINT1
        mobjRobot.RegNumerics(21).Value.RegLong = theta1     '' Point1 x-axis
        mobjRobot.RegNumerics(22).Value.RegLong = theta2     '' Point1 y-axis
        mobjRobot.RegNumerics(23).Value.RegLong = theta3     '' Point1 z-axis
        mobjRobot.RegNumerics(24).Value.RegLong = theta4     '' Point1 w-aangle
        mobjRobot.RegNumerics(25).Value.RegLong = theta5     '' Point1 p-angle
        '%%%%%%%%
        mobjRobot.RegNumerics(20).Value.RegLong = speedJnt

    End Sub




    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    '' Grip Open FUNCTION
    Private Sub gripOpen()

        mobjRobot.RegNumerics(51).Value.RegLong = 1
        mobjRobot.RegNumerics(52).Value.RegLong = 0

    End Sub


    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    '' Grip Close FUNCTION
    Private Sub gripClose()

        mobjRobot.RegNumerics(51).Value.RegLong = 0
        mobjRobot.RegNumerics(52).Value.RegLong = 1

    End Sub


    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    '' Zero the Register Values
    Private Sub zeroRegs()
        Dim counterZR As Integer = 1
        For counterZR = 1 To 200
            mobjRobot.RegNumerics(counterZR).Value.RegLong = 0
        Next counterZR
    End Sub



    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%


    ' Fully releasing COM objects requires waiting for garbage collection
    Private Sub ReleaseObjects()
        mobjRegs = ReleaseObject("mobjRegs", mobjRegs)
        mobjRobot = ReleaseObject("mobjRobot", mobjRobot)
        System.GC.Collect()
    End Sub

    ' Wrap object release in Try-Catch for enhanced diagnostics
    Private Function ReleaseObject(ByVal identifier As String, ByRef item As Object) As Object
        Try
            item = Nothing
        Catch ex As Exception
            System.Diagnostics.Trace.WriteLine(String.Format("Error releasing {0}.{1}Error: {2}", identifier, Environment.NewLine, ex.Message))
        End Try

        Return Nothing
    End Function



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '
        mobjRobot.RegNumerics(1).Value.RegLong = txtRegValue.Text
    End Sub
End Class


