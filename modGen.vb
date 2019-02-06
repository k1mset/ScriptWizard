Imports System.Text

Public Class generator
    Public Shared Function StackPrevention(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Dim StackPrev As System.Random = New System.Random()
        Return StackPrev.Next(Min, Max)
    End Function
    Public Shared Function generate(ByVal target As String, ByVal instant As Boolean, ByVal progbar As Boolean, ByVal progtype As String) As String
        Dim gen As New StringBuilder
        gen.AppendLine(Chr(34) + "Using " + "RC_Core.rcm" + Chr(34))
        gen.AppendLine("Function Main()")
        gen.AppendLine(";//////////////////////////////////////////////////////////////////////////////////////")
        gen.AppendLine("; Generated using RC Spell Wizard v1.0")
        gen.AppendLine("; For use with RealmCrafter v1.26+ and any versions modded from v1.26")
        gen.AppendLine("; If you have additional support questions, help, modifications please contact Piysta")
        gen.AppendLine("; Website: www.realm-store.webs.com")
        gen.AppendLine("; Email: piysta@yahoo.com")
        gen.AppendLine("; RealmCrafter Username: Piysta")
        gen.AppendLine(";//////////////////////////////////////////////////////////////////////////////////////")
        gen.AppendLine(";                           PLEASE REPORT ALL BUGS")
        gen.AppendLine(";//////////////////////////////////////////////////////////////////////////////////////")
        gen.AppendLine(";                           Rules and Understanding")
        gen.AppendLine(";")
        gen.AppendLine(";   You are not allowed to redistribute this script, or any of its contents to any other")
        gen.AppendLine(";   individuals who do not own RC Spell Wizard.")
        gen.AppendLine(";")
        gen.AppendLine(";   You are not allowed to redistribute RC Spell Wizard to any other individuals, nor")
        gen.AppendLine(";   are you allowed to place the software, or its installer online for downloading, or")
        gen.AppendLine(";   backup purposes.")
        gen.AppendLine(";")
        gen.AppendLine(";   You are not allowed to use RC Spell Wizard if you do not own a license to the software.")
        gen.AppendLine(";   ")
        gen.AppendLine(";       These rules are placed to ensure lasting quality and software updates for you,")
        gen.AppendLine(";   as well as all others who have own a license to the software.")
        gen.AppendLine(";")
        gen.AppendLine(";//////////////////////////////////////////////////////////////////////////////////////")
        gen.AppendLine("Player = Actor()")
        gen.AppendLine("Target = ContextActor()")
        gen.AppendLine("Range = " + frmEditor.rngTxt.Text)
        gen.AppendLine("CasterFaction$ = HomeFaction(Player)")
        If frmEditor.chkTarget.Checked = True Then
            gen.AppendLine("TargetFaction$ = HomeFaction(Target)")
            gen.AppendLine("If Target = 0")
            gen.AppendLine("    Output(Player, " + Chr(34) + "You do not have a target." + Chr(34) + ")")
            gen.AppendLine("Else")
            gen.AppendLine("    Distance = ActorDistance(Player, Target)")
            gen.AppendLine("    If Distance > Range")
            gen.AppendLine("        Output(Player, " + Chr(34) + "Target not in range." + Chr(34) + ")")
            gen.AppendLine("    Else")
            If target = "Allies" Then
                gen.AppendLine("        If CasterFaction = TargetFaction")
                gen.AppendLine("            Output(Player, " + Chr(34) + "Unable to cast on enemy targets." + Chr(34) + ")")
                gen.AppendLine("        Else")
            ElseIf target = "Enemies" Then
                gen.AppendLine("        If CasterFaction <> TargetFaction")
                gen.AppendLine("            Output(Player, " + Chr(34) + "Unable to cast on friendly targets." + Chr(34) + ")")
                gen.AppendLine("        Else")
            End If
        End If
        If instant = False Then
            If progbar = True Then
                gen.AppendLine("            Red# = " + frmEditor.progR.Text)
                gen.AppendLine("            Green# = " + frmEditor.progG.Text)
                gen.AppendLine("            Blue# = " + frmEditor.ProgB.Text)
                gen.AppendLine("            X# = " + frmEditor.progX.Text)
                gen.AppendLine("            Y# = " + frmEditor.progY.Text)
                gen.AppendLine("            H# = " + frmEditor.progH.Text)
                gen.AppendLine("            W# = " + frmEditor.progW.Text)
                gen.AppendLine("            Max# = " + frmEditor.progMax.Text + " * 2")
                If progtype = "Filling" Then
                    gen.AppendLine("            Val# = 0")
                ElseIf progtype = "Draining" Then
                    gen.AppendLine("            Val# = Max")
                End If
                gen.AppendLine("            Label$ = " + Chr(34) + frmEditor.progText.Text + Chr(34))
                gen.AppendLine("            CastBar = CreateProgressBar(Player, Red, Green, Blue, X, Y, W, H, Max, Val, Label)")
                If frmEditor.chkInter.Checked = True Then
                    gen.AppendLine("                PlayerX# = ActorX(Player)")
                    gen.AppendLine("                PlayerY# = ActorY(Player)")
                    gen.AppendLine("                PlayerZ# = ActorZ(Player)")
                End If
                If frmEditor.castAniName.Text = "" Then
                Else
                    gen.AppendLine("                AnimateName$ = " + Chr(34) + frmEditor.castAniName.Text + Chr(34))
                    gen.AppendLine("                AnimateSpeed# = " + frmEditor.castAniSpeed.Text)
                    gen.AppendLine("                AnimateActor(Player, AnimateName, AnimateSped)")
                End If
                If progtype = "Filling" Then
                    gen.AppendLine("                Ticks = 0")
                ElseIf progtype = "Draining" Then
                    gen.AppendLine("                Ticks = Max")
                End If
                gen.AppendLine("                Repeat")
                If progtype = "Filling" Then
                    gen.AppendLine("                    Ticks = Ticks + 1")
                ElseIf progtype = "Draining" Then
                    gen.AppendLine("                    Ticks = Ticks - 1")
                End If
                gen.AppendLine("                    DoEvents(500)")
                gen.AppendLine("                    UpdateProgressBar(Player, CastBar, Ticks)")
                If frmEditor.chkInter.Checked = True Then
                    gen.AppendLine("                    NewPlayerX# = ActorX(Player)")
                    gen.AppendLine("                    NewPlayerY# = ActorY(Player)")
                    gen.AppendLine("                    NewPlayerZ# = ActorZ(Player)")
                    gen.AppendLine("                    If PlayerX <> NewPlayerX")
                    gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                        Output(Player, " + Chr(34) + "Spell canceled." + Chr(34) + ")")
                    gen.AppendLine("                        Return")
                    gen.AppendLine("                    ElseIf PlayerY <> NewPlayerY")
                    gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                        Output(Player, " + Chr(34) + "Spell canceled." + Chr(34) + ")")
                    gen.AppendLine("                        Return")
                    gen.AppendLine("                    ElseIf PlayerZ <> NewPlayerZ")
                    gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                        Output(Player, " + Chr(34) + "Spell canceled." + Chr(34) + ")")
                    gen.AppendLine("                        Return")
                    gen.AppendLine("                    EndIf")
                End If
                If frmEditor.chkTarget.Checked = True Then
                    gen.AppendLine("                    NewDistance = ActorDistance(Player, Target)")
                    gen.AppendLine("                    If NewDistance > Range")
                    gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                        Output(Player, " + Chr(34) + "Target out of range." + Chr(34) + ")")
                    gen.AppendLine("                        Return")
                    gen.AppendLine("                    EndIf")
                End If
                'SPELLREQUIREMENTS
                If frmEditor.spellreqAtr1.Text = "" Then
                Else
                    gen.AppendLine("                    AtrName$ = " + Chr(34) + frmEditor.spellreqAtr1.Text + Chr(34))
                    gen.AppendLine("                    AtrAmount = " + frmEditor.spellreqAmt1.Text)
                    gen.AppendLine("                    Attri = Attribute(Player, AtrName)")
                    gen.AppendLine("                    If Attri < AtrAmt")
                    gen.AppendLine("                        Output(Player, " + Chr(34) + "You do not have the required " + frmEditor.spellreqAtr1.Text + "." + Chr(34) + ")")
                    gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                        Return")
                    gen.AppendLine("                    EndIf")
                End If
                If frmEditor.spellreqAtr2.Text = "" Then
                Else
                    gen.AppendLine("                    AtrName$ = " + Chr(34) + frmEditor.spellreqAtr2.Text + Chr(34))
                    gen.AppendLine("                    AtrAmount = " + frmEditor.spellreqAmt2.Text)
                    gen.AppendLine("                    Attri = Attribute(Player, AtrName)")
                    gen.AppendLine("                    If Attri < AtrAmt")
                    gen.AppendLine("                        Output(Player, " + Chr(34) + "You do not have the required " + frmEditor.spellreqAtr2.Text + "." + Chr(34) + ")")
                    gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                        Return")
                    gen.AppendLine("                    EndIf")
                End If
                If frmEditor.spellreqAtr3.Text = "" Then
                Else
                    gen.AppendLine("                    AtrName$ = " + Chr(34) + frmEditor.spellreqAtr3.Text + Chr(34))
                    gen.AppendLine("                    AtrAmount = " + frmEditor.spellreqAmt3.Text)
                    gen.AppendLine("                    Attri = Attribute(Player, AtrName)")
                    gen.AppendLine("                    If Attri < AtrAmt")
                    gen.AppendLine("                        Output(Player, " + Chr(34) + "You do not have the required " + frmEditor.spellreqAtr3.Text + "." + Chr(34) + ")")
                    gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                        Return")
                    gen.AppendLine("                    EndIf")
                End If
                If frmEditor.spellreqAtr4.Text = "" Then
                Else
                    gen.AppendLine("                    AtrName$ = " + Chr(34) + frmEditor.spellreqAtr4.Text + Chr(34))
                    gen.AppendLine("                    AtrAmount = " + frmEditor.spellreqAmt4.Text)
                    gen.AppendLine("                    Attri = Attribute(Player, AtrName)")
                    gen.AppendLine("                    If Attri < AtrAmt")
                    gen.AppendLine("                        Output(Player, " + Chr(34) + "You do not have the required " + frmEditor.spellreqAtr4.Text + "." + Chr(34) + ")")
                    gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                        Return")
                    gen.AppendLine("                    EndIf")
                End If
                If frmEditor.spellreqAtr5.Text = "" Then
                Else
                    gen.AppendLine("                    AtrName$ = " + Chr(34) + frmEditor.spellreqAtr5.Text + Chr(34))
                    gen.AppendLine("                    AtrAmount = " + frmEditor.spellreqAmt5.Text)
                    gen.AppendLine("                    Attri = Attribute(Player, AtrName)")
                    gen.AppendLine("                    If Attri < AtrAmt")
                    gen.AppendLine("                        Output(Player, " + Chr(34) + "You do not have the required " + frmEditor.spellreqAtr5.Text + "." + Chr(34) + ")")
                    gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                        Return")
                    gen.AppendLine("                    EndIf")
                End If
                If frmEditor.buffreqC1.Text = "" Then
                Else
                    gen.AppendLine("                    BuffName$ = " + Chr(34) + frmEditor.buffreqC1.Text + Chr(34))
                    gen.AppendLine("                    Effect = ActorHasEffect(Player, BuffName)")
                    If frmEditor.buffreqCR1.Checked = True Then
                        gen.AppendLine("                    If Effect = 1")
                        gen.AppendLine("                        Output(Player, " + Chr(34) + "Unable to cast while " + frmEditor.buffreqC1.Text + "." + Chr(34) + ")")
                        gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                        gen.AppendLine("                        Return")
                        gen.AppendLine("                    EndIf")
                    Else
                        gen.AppendLine("                    If Effect = 0")
                        gen.AppendLine("                        Output(Player, " + Chr(34) + "You require " + frmEditor.buffreqC1.Text + " to cast." + Chr(34) + ")")
                        gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                        gen.AppendLine("                        Return")
                        gen.AppendLine("                    EndIf")
                    End If
                End If
                If frmEditor.buffreqC2.Text = "" Then
                Else
                    gen.AppendLine("                    BuffName$ = " + Chr(34) + frmEditor.buffreqC2.Text + Chr(34))
                    gen.AppendLine("                    Effect = ActorHasEffect(Player, BuffName)")
                    If frmEditor.buffreqCR2.Checked = True Then
                        gen.AppendLine("                    If Effect = 1")
                        gen.AppendLine("                        Output(Player, " + Chr(34) + "Unable to cast while " + frmEditor.buffreqC2.Text + "." + Chr(34) + ")")
                        gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                        gen.AppendLine("                        Return")
                        gen.AppendLine("                    EndIf")
                    Else
                        gen.AppendLine("                    If Effect = 0")
                        gen.AppendLine("                        Output(Player, " + Chr(34) + "You require " + frmEditor.buffreqC2.Text + " to cast." + Chr(34) + ")")
                        gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                        gen.AppendLine("                        Return")
                        gen.AppendLine("                    EndIf")
                    End If
                End If
                If frmEditor.buffreqC3.Text = "" Then
                Else
                    gen.AppendLine("                    BuffName$ = " + Chr(34) + frmEditor.buffreqC3.Text + Chr(34))
                    gen.AppendLine("                    Effect = ActorHasEffect(Player, BuffName)")
                    If frmEditor.buffreqCR3.Checked = True Then
                        gen.AppendLine("                    If Effect = 1")
                        gen.AppendLine("                        Output(Player, " + Chr(34) + "Unable to cast while " + frmEditor.buffreqC3.Text + "." + Chr(34) + ")")
                        gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                        gen.AppendLine("                        Return")
                        gen.AppendLine("                    EndIf")
                    Else
                        gen.AppendLine("                    If Effect = 0")
                        gen.AppendLine("                        Output(Player, " + Chr(34) + "You require " + frmEditor.buffreqC3.Text + " to cast." + Chr(34) + ")")
                        gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                        gen.AppendLine("                        Return")
                        gen.AppendLine("                    EndIf")
                    End If
                End If
                If frmEditor.buffreqC4.Text = "" Then
                Else
                    gen.AppendLine("                    BuffName$ = " + Chr(34) + frmEditor.buffreqC4.Text + Chr(34))
                    gen.AppendLine("                    Effect = ActorHasEffect(Player, BuffName)")
                    If frmEditor.buffreqCR4.Checked = True Then
                        gen.AppendLine("                    If Effect = 1")
                        gen.AppendLine("                        Output(Player, " + Chr(34) + "Unable to cast while " + frmEditor.buffreqC4.Text + "." + Chr(34) + ")")
                        gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                        gen.AppendLine("                        Return")
                        gen.AppendLine("                    EndIf")
                    Else
                        gen.AppendLine("                    If Effect = 0")
                        gen.AppendLine("                        Output(Player, " + Chr(34) + "You require " + frmEditor.buffreqC4.Text + " to cast." + Chr(34) + ")")
                        gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                        gen.AppendLine("                        Return")
                        gen.AppendLine("                    EndIf")
                    End If
                End If
                If frmEditor.buffreqC5.Text = "" Then
                Else
                    gen.AppendLine("                    BuffName$ = " + Chr(34) + frmEditor.buffreqC5.Text + Chr(34))
                    gen.AppendLine("                    Effect = ActorHasEffect(Player, BuffName)")
                    If frmEditor.buffreqCR5.Checked = True Then
                        gen.AppendLine("                    If Effect = 1")
                        gen.AppendLine("                        Output(Player, " + Chr(34) + "Unable to cast while " + frmEditor.buffreqC5.Text + "." + Chr(34) + ")")
                        gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                        gen.AppendLine("                        Return")
                        gen.AppendLine("                    EndIf")
                    Else
                        gen.AppendLine("                    If Effect = 0")
                        gen.AppendLine("                        Output(Player, " + Chr(34) + "You require " + frmEditor.buffreqC5.Text + " to cast." + Chr(34) + ")")
                        gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                        gen.AppendLine("                        Return")
                        gen.AppendLine("                    EndIf")
                    End If
                End If
                If frmEditor.chkTarget.Checked = True Then
                    If frmEditor.buffreqT1.Text = "" Then
                    Else
                        gen.AppendLine("                    BuffName$ = " + Chr(34) + frmEditor.buffreqT1.Text + Chr(34))
                        gen.AppendLine("                    Effect = ActorHasEffect(Target, BuffName)")
                        If frmEditor.buffreqTR1.Checked = True Then
                            gen.AppendLine("                    If Effect = 1")
                            gen.AppendLine("                        Output(Player, " + Chr(34) + "Unable to cast while target is " + frmEditor.buffreqT1.Text + "." + Chr(34) + ")")
                            gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                            gen.AppendLine("                        Return")
                            gen.AppendLine("                    EndIf")
                        Else
                            gen.AppendLine("                    If Effect = 0")
                            gen.AppendLine("                        Output(Player, " + Chr(34) + "Target requires " + frmEditor.buffreqT1.Text + " to cast." + Chr(34) + ")")
                            gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                            gen.AppendLine("                        Return")
                            gen.AppendLine("                    EndIf")
                        End If
                    End If
                    If frmEditor.buffreqT2.Text = "" Then
                    Else
                        gen.AppendLine("                    BuffName$ = " + Chr(34) + frmEditor.buffreqT2.Text + Chr(34))
                        gen.AppendLine("                    Effect = ActorHasEffect(Target, BuffName)")
                        If frmEditor.buffreqTR2.Checked = True Then
                            gen.AppendLine("                    If Effect = 1")
                            gen.AppendLine("                        Output(Player, " + Chr(34) + "Unable to cast while target is " + frmEditor.buffreqT2.Text + "." + Chr(34) + ")")
                            gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                            gen.AppendLine("                        Return")
                            gen.AppendLine("                    EndIf")
                        Else
                            gen.AppendLine("                    If Effect = 0")
                            gen.AppendLine("                        Output(Player, " + Chr(34) + "Target requires " + frmEditor.buffreqT2.Text + " to cast." + Chr(34) + ")")
                            gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                            gen.AppendLine("                        Return")
                            gen.AppendLine("                    EndIf")
                        End If
                    End If
                    If frmEditor.buffreqT3.Text = "" Then
                    Else
                        gen.AppendLine("                    BuffName$ = " + Chr(34) + frmEditor.buffreqT3.Text + Chr(34))
                        gen.AppendLine("                    Effect = ActorHasEffect(Target, BuffName)")
                        If frmEditor.buffreqTR3.Checked = True Then
                            gen.AppendLine("                    If Effect = 1")
                            gen.AppendLine("                        Output(Player, " + Chr(34) + "Unable to cast while target is " + frmEditor.buffreqT3.Text + "." + Chr(34) + ")")
                            gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                            gen.AppendLine("                        Return")
                            gen.AppendLine("                    EndIf")
                        Else
                            gen.AppendLine("                    If Effect = 0")
                            gen.AppendLine("                        Output(Player, " + Chr(34) + "Target requires " + frmEditor.buffreqT3.Text + " to cast." + Chr(34) + ")")
                            gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                            gen.AppendLine("                        Return")
                            gen.AppendLine("                    EndIf")
                        End If
                    End If
                    If frmEditor.buffreqT4.Text = "" Then
                    Else
                        gen.AppendLine("                    BuffName$ = " + Chr(34) + frmEditor.buffreqT4.Text + Chr(34))
                        gen.AppendLine("                    Effect = ActorHasEffect(Target, BuffName)")
                        If frmEditor.buffreqTR4.Checked = True Then
                            gen.AppendLine("                    If Effect = 1")
                            gen.AppendLine("                        Output(Player, " + Chr(34) + "Unable to cast while target is " + frmEditor.buffreqT4.Text + "." + Chr(34) + ")")
                            gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                            gen.AppendLine("                        Return")
                            gen.AppendLine("                    EndIf")
                        Else
                            gen.AppendLine("                    If Effect = 0")
                            gen.AppendLine("                        Output(Player, " + Chr(34) + "Target requires " + frmEditor.buffreqT4.Text + " to cast." + Chr(34) + ")")
                            gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                            gen.AppendLine("                        Return")
                            gen.AppendLine("                    EndIf")
                        End If
                    End If
                    If frmEditor.buffreqT5.Text = "" Then
                    Else
                        gen.AppendLine("                    BuffName$ = " + Chr(34) + frmEditor.buffreqT5.Text + Chr(34))
                        gen.AppendLine("                    Effect = ActorHasEffect(Target, BuffName)")
                        If frmEditor.buffreqTR5.Checked = True Then
                            gen.AppendLine("                    If Effect = 1")
                            gen.AppendLine("                        Output(Player, " + Chr(34) + "Unable to cast while target is " + frmEditor.buffreqT5.Text + "." + Chr(34) + ")")
                            gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                            gen.AppendLine("                        Return")
                            gen.AppendLine("                    EndIf")
                        Else
                            gen.AppendLine("                    If Effect = 0")
                            gen.AppendLine("                        Output(Player, " + Chr(34) + "Target requires " + frmEditor.buffreqT5.Text + " to cast." + Chr(34) + ")")
                            gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                            gen.AppendLine("                        Return")
                            gen.AppendLine("                    EndIf")
                        End If
                    End If
                End If
                If frmEditor.itmreqN1.Text = "" Then
                Else
                    gen.AppendLine("                    ItemCheckName =" + Chr(34) + frmEditor.itmreqN1.Text + Chr(34))
                    gen.AppendLine("                    ItemAmount = " + frmEditor.itmreqA1.Text)
                    gen.AppendLine("                    Has = HasItem(Player, ItemCheckName, ItemAmount)")
                    gen.AppendLine("                    If Has = 0")
                    gen.AppendLine("                        Output(Player, " + Chr(34) + "Missing required item: " + frmEditor.itmreqN1.Text + "." + Chr(34) + ")")
                    gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                        Return")
                    gen.AppendLine("                    EndIf")
                End If
                If frmEditor.itmreqN2.Text = "" Then
                Else
                    gen.AppendLine("                    ItemCheckName$ =" + Chr(34) + frmEditor.itmreqN2.Text + Chr(34))
                    gen.AppendLine("                    ItemAmount = " + frmEditor.itmreqA2.Text)
                    gen.AppendLine("                    Has = HasItem(Player, ItemCheckName, ItemAmount)")
                    gen.AppendLine("                    If Has = 0")
                    gen.AppendLine("                        Output(Player, " + Chr(34) + "Missing required item: " + frmEditor.itmreqN2.Text + "." + Chr(34) + ")")
                    gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                        Return")
                    gen.AppendLine("                    EndIf")
                End If
                If frmEditor.itmreqN3.Text = "" Then
                Else
                    gen.AppendLine("                    ItemCheckName$ =" + Chr(34) + frmEditor.itmreqN3.Text + Chr(34))
                    gen.AppendLine("                    ItemAmount = " + frmEditor.itmreqA3.Text)
                    gen.AppendLine("                    Has = HasItem(Player, ItemCheckName, ItemAmount)")
                    gen.AppendLine("                    If Has = 0")
                    gen.AppendLine("                        Output(Player, " + Chr(34) + "Missing required item: " + frmEditor.itmreqN3.Text + "." + Chr(34) + ")")
                    gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                        Return")
                    gen.AppendLine("                    EndIf")
                End If
                If frmEditor.itmreqN4.Text = "" Then
                Else
                    gen.AppendLine("                    ItemCheckName$ =" + Chr(34) + frmEditor.itmreqN4.Text + Chr(34))
                    gen.AppendLine("                    ItemAmount = " + frmEditor.itmreqA4.Text)
                    gen.AppendLine("                    Has = HasItem(Player, ItemCheckName, ItemAmount)")
                    gen.AppendLine("                    If Has = 0")
                    gen.AppendLine("                        Output(Player, " + Chr(34) + "Missing required item: " + frmEditor.itmreqN4.Text + "." + Chr(34) + ")")
                    gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                        Return")
                    gen.AppendLine("                    EndIf")
                End If
                If frmEditor.itmreqN5.Text = "" Then
                Else
                    gen.AppendLine("                    ItemCheckName$ =" + Chr(34) + frmEditor.itmreqN5.Text + Chr(34))
                    gen.AppendLine("                    ItemAmount = " + frmEditor.itmreqA5.Text)
                    gen.AppendLine("                    Has = HasItem(Player, ItemCheckName, ItemAmount)")
                    gen.AppendLine("                    If Has = 0")
                    gen.AppendLine("                        Output(Player, " + Chr(34) + "Missing required item: " + frmEditor.itmreqN5.Text + "." + Chr(34) + ")")
                    gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                        Return")
                    gen.AppendLine("                    EndIf")
                End If
                If frmEditor.gldR.Text = "" Then
                Else
                    gen.AppendLine("                    GoldReq# = " + frmEditor.gldR.Text)
                    gen.AppendLine("                    PlayerGold# = Money(Player)")
                    gen.AppendLine("                    If PlayerGold < GoldReq")
                    gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                        Output(Player, " + Chr(34) + "You do not have the required money." + Chr(34) + ")")
                    gen.AppendLine("                        Return")
                    gen.AppendLine("                    EndIf")
                End If
                If frmEditor.lvl.Text = "" Then
                Else
                    gen.AppendLine("                    LevelReq# = " + frmEditor.lvl.Text)
                    gen.AppendLine("                    PlayerLevel# = ActorLevel(Player)")
                    gen.AppendLine("                    If PlayerLevel < LevelReq")
                    gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                        Output(Player, " + Chr(34) + "You are not the required level." + Chr(34) + ")")
                    gen.AppendLine("                        Return")
                    gen.AppendLine("                    EndIf")
                End If
                If frmEditor.repreq.Text = "" Then
                Else
                    gen.AppendLine("                    RepReq# = " + frmEditor.repreq.Text)
                    gen.AppendLine("                    PlayerRep# = Reputation(Player)")
                    gen.AppendLine("                    If PlayerRep < RepReq")
                    gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                        Output(Player, " + Chr(34) + "Your reputation is too low." + Chr(34) + ")")
                    gen.AppendLine("                        Return")
                    gen.AppendLine("                    EndIf")
                End If
                If frmEditor.gmstat.Checked = True Then
                    gen.AppendLine("                    GM = PlayerIsGM(Player)")
                    gen.AppendLine("                    If GM = 0")
                    gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                        Output(Player, " + Chr(34) + "Unable to cast due to server authorization level." + Chr(34) + ")")
                    gen.AppendLine("                        Return")
                    gen.AppendLine("                    EndIf")
                End If
                If frmEditor.race.Text = "" Then
                Else
                    gen.AppendLine("                    RaceReq# = " + frmEditor.race.Text)
                    gen.AppendLine("                    PlayerRace# = Race(Player)")
                    gen.AppendLine("                    If PlayerRace <> RaceReq")
                    gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                        Output(Player, " + Chr(34) + "You're not the required race." + Chr(34) + ")")
                    gen.AppendLine("                        Return")
                    gen.AppendLine("                    EndIf")
                End If
                If frmEditor.clss.Text = "" Then
                Else
                    gen.AppendLine("                    ClassReq# = " + frmEditor.clss.Text)
                    gen.AppendLine("                    PlayerClass# = Class(Player)")
                    gen.AppendLine("                    If PlayerClass <> ClassReq")
                    gen.AppendLine("                        DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                        Output(Player, " + Chr(34) + "You're not the required class." + Chr(34) + ")")
                    gen.AppendLine("                        Return")
                    gen.AppendLine("                    EndIf")
                End If
                If frmEditor.castAniName.Text = "" Then
                Else
                    gen.AppendLine("                    AnimateName = " + Chr(34) + frmEditor.castAniName.Text + Chr(34))
                    gen.AppendLine("                    AnimateSpeed = " + frmEditor.castAniSpeed.Text)
                    gen.AppendLine("                    AnimateActor(Player, AnimateName, AnimateSpeed)")
                End If
                If frmEditor.cmbProgType.SelectedItem = "Filling" Then
                    gen.AppendLine("                Until Ticks = Max")
                ElseIf frmEditor.cmbProgType.SelectedItem = "Draining" Then
                    gen.AppendLine("                Until Ticks = 0")
                End If
                gen.AppendLine("                DeleteProgressBar(Player, CastBar)")
            End If
            'INSTANTCAST
        Else
            If frmEditor.spellreqAtr1.Text = "" Then
            Else
                gen.AppendLine("                AtrName$ = " + Chr(34) + frmEditor.spellreqAtr1.Text + Chr(34))
                gen.AppendLine("                AtrAmount = " + frmEditor.spellreqAmt1.Text)
                gen.AppendLine("                Attri = Attribute(Player, AtrName)")
                gen.AppendLine("                If Attri < AtrAmt")
                gen.AppendLine("                    Output(Player, " + Chr(34) + "You do not have the required " + frmEditor.spellreqAtr1.Text + "." + Chr(34) + ")")
                gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                gen.AppendLine("                    Return")
                gen.AppendLine("                EndIf")
            End If
            If frmEditor.spellreqAtr2.Text = "" Then
            Else
                gen.AppendLine("                AtrName$ = " + Chr(34) + frmEditor.spellreqAtr2.Text + Chr(34))
                gen.AppendLine("                AtrAmount = " + frmEditor.spellreqAmt2.Text)
                gen.AppendLine("                Attri = Attribute(Player, AtrName)")
                gen.AppendLine("                If Attri < AtrAmt")
                gen.AppendLine("                    Output(Player, " + Chr(34) + "You do not have the required " + frmEditor.spellreqAtr2.Text + "." + Chr(34) + ")")
                gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                gen.AppendLine("                    Return")
                gen.AppendLine("                EndIf")
            End If
            If frmEditor.spellreqAtr3.Text = "" Then
            Else
                gen.AppendLine("                AtrName$ = " + Chr(34) + frmEditor.spellreqAtr3.Text + Chr(34))
                gen.AppendLine("                AtrAmount = " + frmEditor.spellreqAmt3.Text)
                gen.AppendLine("                Attri = Attribute(Player, AtrName)")
                gen.AppendLine("                If Attri < AtrAmt")
                gen.AppendLine("                    Output(Player, " + Chr(34) + "You do not have the required " + frmEditor.spellreqAtr3.Text + "." + Chr(34) + ")")
                gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                gen.AppendLine("                    Return")
                gen.AppendLine("                EndIf")
            End If
            If frmEditor.spellreqAtr4.Text = "" Then
            Else
                gen.AppendLine("                AtrName$ = " + Chr(34) + frmEditor.spellreqAtr4.Text + Chr(34))
                gen.AppendLine("                AtrAmount = " + frmEditor.spellreqAmt4.Text)
                gen.AppendLine("                Attri = Attribute(Player, AtrName)")
                gen.AppendLine("                If Attri < AtrAmt")
                gen.AppendLine("                    Output(Player, " + Chr(34) + "You do not have the required " + frmEditor.spellreqAtr4.Text + "." + Chr(34) + ")")
                gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                gen.AppendLine("                    Return")
                gen.AppendLine("                EndIf")
            End If
            If frmEditor.spellreqAtr5.Text = "" Then
            Else
                gen.AppendLine("                AtrName$ = " + Chr(34) + frmEditor.spellreqAtr5.Text + Chr(34))
                gen.AppendLine("                AtrAmount = " + frmEditor.spellreqAmt5.Text)
                gen.AppendLine("                Attri = Attribute(Player, AtrName)")
                gen.AppendLine("                If Attri < AtrAmt")
                gen.AppendLine("                    Output(Player, " + Chr(34) + "You do not have the required " + frmEditor.spellreqAtr5.Text + "." + Chr(34) + ")")
                gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                gen.AppendLine("                    Return")
                gen.AppendLine("                EndIf")
            End If
            If frmEditor.buffreqC1.Text = "" Then
            Else
                gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.buffreqC1.Text + Chr(34))
                gen.AppendLine("                Effect = ActorHasEffect(Player, BuffName)")
                If frmEditor.buffreqCR1.Checked = True Then
                    gen.AppendLine("                If Effect = 1")
                    gen.AppendLine("                    Output(Player, " + Chr(34) + "Unable to cast while " + frmEditor.buffreqC1.Text + "." + Chr(34) + ")")
                    gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                    Return")
                    gen.AppendLine("                EndIf")
                Else
                    gen.AppendLine("                If Effect = 0")
                    gen.AppendLine("                    Output(Player, " + Chr(34) + "You require " + frmEditor.buffreqC1.Text + " to cast." + Chr(34) + ")")
                    gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                    Return")
                    gen.AppendLine("                EndIf")
                End If
            End If
            If frmEditor.buffreqC2.Text = "" Then
            Else
                gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.buffreqC2.Text + Chr(34))
                gen.AppendLine("                Effect = ActorHasEffect(Player, BuffName)")
                If frmEditor.buffreqCR2.Checked = True Then
                    gen.AppendLine("                If Effect = 1")
                    gen.AppendLine("                    Output(Player, " + Chr(34) + "Unable to cast while " + frmEditor.buffreqC2.Text + "." + Chr(34) + ")")
                    gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                    Return")
                    gen.AppendLine("                EndIf")
                Else
                    gen.AppendLine("                If Effect = 0")
                    gen.AppendLine("                    Output(Player, " + Chr(34) + "You require " + frmEditor.buffreqC2.Text + " to cast." + Chr(34) + ")")
                    gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                    Return")
                    gen.AppendLine("                EndIf")
                End If
            End If
            If frmEditor.buffreqC3.Text = "" Then
            Else
                gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.buffreqC3.Text + Chr(34))
                gen.AppendLine("                Effect = ActorHasEffect(Player, BuffName)")
                If frmEditor.buffreqCR3.Checked = True Then
                    gen.AppendLine("                If Effect = 1")
                    gen.AppendLine("                    Output(Player, " + Chr(34) + "Unable to cast while " + frmEditor.buffreqC3.Text + "." + Chr(34) + ")")
                    gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                    Return")
                    gen.AppendLine("                EndIf")
                Else
                    gen.AppendLine("                If Effect = 0")
                    gen.AppendLine("                    Output(Player, " + Chr(34) + "You require " + frmEditor.buffreqC3.Text + " to cast." + Chr(34) + ")")
                    gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                    Return")
                    gen.AppendLine("                EndIf")
                End If
            End If
            If frmEditor.buffreqC4.Text = "" Then
            Else
                gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.buffreqC4.Text + Chr(34))
                gen.AppendLine("                Effect = ActorHasEffect(Player, BuffName)")
                If frmEditor.buffreqCR4.Checked = True Then
                    gen.AppendLine("                If Effect = 1")
                    gen.AppendLine("                    Output(Player, " + Chr(34) + "Unable to cast while " + frmEditor.buffreqC4.Text + "." + Chr(34) + ")")
                    gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                    Return")
                    gen.AppendLine("                EndIf")
                Else
                    gen.AppendLine("                If Effect = 0")
                    gen.AppendLine("                    Output(Player, " + Chr(34) + "You require " + frmEditor.buffreqC4.Text + " to cast." + Chr(34) + ")")
                    gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                    Return")
                    gen.AppendLine("                EndIf")
                End If
            End If
            If frmEditor.buffreqC5.Text = "" Then
            Else
                gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.buffreqC5.Text + Chr(34))
                gen.AppendLine("                Effect = ActorHasEffect(Player, BuffName)")
                If frmEditor.buffreqCR5.Checked = True Then
                    gen.AppendLine("                If Effect = 1")
                    gen.AppendLine("                    Output(Player, " + Chr(34) + "Unable to cast while " + frmEditor.buffreqC5.Text + "." + Chr(34) + ")")
                    gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                    Return")
                    gen.AppendLine("                EndIf")
                Else
                    gen.AppendLine("                If Effect = 0")
                    gen.AppendLine("                    Output(Player, " + Chr(34) + "You require " + frmEditor.buffreqC5.Text + " to cast." + Chr(34) + ")")
                    gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                    gen.AppendLine("                    Return")
                    gen.AppendLine("                EndIf")
                End If
            End If
            If frmEditor.chkTarget.Checked = True Then
                If frmEditor.buffreqT1.Text = "" Then
                Else
                    gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.buffreqT1.Text + Chr(34))
                    gen.AppendLine("                Effect = ActorHasEffect(Target, BuffName)")
                    If frmEditor.buffreqTR1.Checked = True Then
                        gen.AppendLine("                If Effect = 1")
                        gen.AppendLine("                    Output(Player, " + Chr(34) + "Unable to cast while target is " + frmEditor.buffreqT1.Text + "." + Chr(34) + ")")
                        gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                        gen.AppendLine("                    Return")
                        gen.AppendLine("                EndIf")
                    Else
                        gen.AppendLine("                If Effect = 0")
                        gen.AppendLine("                    Output(Player, " + Chr(34) + "Target requires " + frmEditor.buffreqT1.Text + " to cast." + Chr(34) + ")")
                        gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                        gen.AppendLine("                    Return")
                        gen.AppendLine("                EndIf")
                    End If
                End If
                If frmEditor.buffreqT2.Text = "" Then
                Else
                    gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.buffreqT2.Text + Chr(34))
                    gen.AppendLine("                Effect = ActorHasEffect(Target, BuffName)")
                    If frmEditor.buffreqTR2.Checked = True Then
                        gen.AppendLine("                If Effect = 1")
                        gen.AppendLine("                    Output(Player, " + Chr(34) + "Unable to cast while target is " + frmEditor.buffreqT2.Text + "." + Chr(34) + ")")
                        gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                        gen.AppendLine("                    Return")
                        gen.AppendLine("                EndIf")
                    Else
                        gen.AppendLine("                If Effect = 0")
                        gen.AppendLine("                    Output(Player, " + Chr(34) + "Target requires " + frmEditor.buffreqT2.Text + " to cast." + Chr(34) + ")")
                        gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                        gen.AppendLine("                    Return")
                        gen.AppendLine("                EndIf")
                    End If
                End If
                If frmEditor.buffreqT3.Text = "" Then
                Else
                    gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.buffreqT3.Text + Chr(34))
                    gen.AppendLine("                Effect = ActorHasEffect(Target, BuffName)")
                    If frmEditor.buffreqTR3.Checked = True Then
                        gen.AppendLine("                If Effect = 1")
                        gen.AppendLine("                    Output(Player, " + Chr(34) + "Unable to cast while target is " + frmEditor.buffreqT3.Text + "." + Chr(34) + ")")
                        gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                        gen.AppendLine("                    Return")
                        gen.AppendLine("                EndIf")
                    Else
                        gen.AppendLine("                If Effect = 0")
                        gen.AppendLine("                    Output(Player, " + Chr(34) + "Target requires " + frmEditor.buffreqT3.Text + " to cast." + Chr(34) + ")")
                        gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                        gen.AppendLine("                    Return")
                        gen.AppendLine("                EndIf")
                    End If
                End If
                If frmEditor.buffreqT4.Text = "" Then
                Else
                    gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.buffreqT4.Text + Chr(34))
                    gen.AppendLine("                Effect = ActorHasEffect(Target, BuffName)")
                    If frmEditor.buffreqTR4.Checked = True Then
                        gen.AppendLine("                If Effect = 1")
                        gen.AppendLine("                    Output(Player, " + Chr(34) + "Unable to cast while target is " + frmEditor.buffreqT4.Text + "." + Chr(34) + ")")
                        gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                        gen.AppendLine("                    Return")
                        gen.AppendLine("                EndIf")
                    Else
                        gen.AppendLine("                If Effect = 0")
                        gen.AppendLine("                    Output(Player, " + Chr(34) + "Target requires " + frmEditor.buffreqT4.Text + " to cast." + Chr(34) + ")")
                        gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                        gen.AppendLine("                    Return")
                        gen.AppendLine("                EndIf")
                    End If
                End If
                If frmEditor.buffreqT5.Text = "" Then
                Else
                    gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.buffreqT5.Text + Chr(34))
                    gen.AppendLine("                Effect = ActorHasEffect(Target, BuffName)")
                    If frmEditor.buffreqTR5.Checked = True Then
                        gen.AppendLine("                If Effect = 1")
                        gen.AppendLine("                    Output(Player, " + Chr(34) + "Unable to cast while target is " + frmEditor.buffreqT5.Text + "." + Chr(34) + ")")
                        gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                        gen.AppendLine("                    Return")
                        gen.AppendLine("                EndIf")
                    Else
                        gen.AppendLine("                If Effect = 0")
                        gen.AppendLine("                    Output(Player, " + Chr(34) + "Target requires " + frmEditor.buffreqT5.Text + " to cast." + Chr(34) + ")")
                        gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                        gen.AppendLine("                    Return")
                        gen.AppendLine("                EndIf")
                    End If
                End If
            End If
            If frmEditor.itmreqN1.Text = "" Then
            Else
                gen.AppendLine("                ItemCheckName$ =" + Chr(34) + frmEditor.itmreqN1.Text + Chr(34))
                gen.AppendLine("                ItemAmount = " + frmEditor.itmreqA1.Text)
                gen.AppendLine("                Has = HasItem(Player, ItemCheckName, ItemAmount)")
                gen.AppendLine("                If Has = 0")
                gen.AppendLine("                    Output(Player, " + Chr(34) + "Missing required item: " + frmEditor.itmreqN1.Text + "." + Chr(34) + ")")
                gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                gen.AppendLine("                    Return")
                gen.AppendLine("                EndIf")
            End If
            If frmEditor.itmreqN2.Text = "" Then
            Else
                gen.AppendLine("                ItemCheckName$ =" + Chr(34) + frmEditor.itmreqN2.Text + Chr(34))
                gen.AppendLine("                ItemAmount = " + frmEditor.itmreqA2.Text)
                gen.AppendLine("                Has = HasItem(Player, ItemCheckName, ItemAmount)")
                gen.AppendLine("                If Has = 0")
                gen.AppendLine("                    Output(Player, " + Chr(34) + "Missing required item: " + frmEditor.itmreqN2.Text + "." + Chr(34) + ")")
                gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                gen.AppendLine("                    Return")
                gen.AppendLine("                EndIf")
            End If
            If frmEditor.itmreqN3.Text = "" Then
            Else
                gen.AppendLine("                ItemCheckName$ =" + Chr(34) + frmEditor.itmreqN3.Text + Chr(34))
                gen.AppendLine("                ItemAmount = " + frmEditor.itmreqA3.Text)
                gen.AppendLine("                Has = HasItem(Player, ItemCheckName, ItemAmount)")
                gen.AppendLine("                If Has = 0")
                gen.AppendLine("                    Output(Player, " + Chr(34) + "Missing required item: " + frmEditor.itmreqN3.Text + "." + Chr(34) + ")")
                gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                gen.AppendLine("                    Return")
                gen.AppendLine("                EndIf")
            End If
            If frmEditor.itmreqN4.Text = "" Then
            Else
                gen.AppendLine("                ItemCheckName$ =" + Chr(34) + frmEditor.itmreqN4.Text + Chr(34))
                gen.AppendLine("                ItemAmount = " + frmEditor.itmreqA4.Text)
                gen.AppendLine("                Has = HasItem(Player, ItemCheckName, ItemAmount)")
                gen.AppendLine("                If Has = 0")
                gen.AppendLine("                    Output(Player, " + Chr(34) + "Missing required item: " + frmEditor.itmreqN4.Text + "." + Chr(34) + ")")
                gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                gen.AppendLine("                    Return")
                gen.AppendLine("                EndIf")
            End If
            If frmEditor.itmreqN5.Text = "" Then
            Else
                gen.AppendLine("                ItemCheckName$ =" + Chr(34) + frmEditor.itmreqN5.Text + Chr(34))
                gen.AppendLine("                ItemAmount = " + frmEditor.itmreqA5.Text)
                gen.AppendLine("                Has = HasItem(Player, ItemCheckName, ItemAmount)")
                gen.AppendLine("                If Has = 0")
                gen.AppendLine("                    Output(Player, " + Chr(34) + "Missing required item: " + frmEditor.itmreqN5.Text + "." + Chr(34) + ")")
                gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                gen.AppendLine("                    Return")
                gen.AppendLine("                EndIf")
            End If
            If frmEditor.gldR.Text = "" Then
            Else
                gen.AppendLine("                GoldReq# = " + frmEditor.gldR.Text)
                gen.AppendLine("                PlayerGold# = Money(Player)")
                gen.AppendLine("                If PlayerGold < GoldReq")
                gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                gen.AppendLine("                    Output(Player, " + Chr(34) + "You do not have the required money." + Chr(34) + ")")
                gen.AppendLine("                    Return")
                gen.AppendLine("                EndIf")
            End If
            If frmEditor.lvl.Text = "" Then
            Else
                gen.AppendLine("                LevelReq# = " + frmEditor.lvl.Text)
                gen.AppendLine("                PlayerLevel# = ActorLevel(Player)")
                gen.AppendLine("                If PlayerLevel < LevelReq")
                gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                gen.AppendLine("                    Output(Player, " + Chr(34) + "You are not the required level." + Chr(34) + ")")
                gen.AppendLine("                    Return")
                gen.AppendLine("                EndIf")
            End If
            If frmEditor.repreq.Text = "" Then
            Else
                gen.AppendLine("                RepReq# = " + frmEditor.repreq.Text)
                gen.AppendLine("                PlayerRep# = Reputation(Player)")
                gen.AppendLine("                If PlayerRep < RepReq")
                gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                gen.AppendLine("                    Output(Player, " + Chr(34) + "Your reputation is too low." + Chr(34) + ")")
                gen.AppendLine("                    Return")
                gen.AppendLine("                EndIf")
            End If
            If frmEditor.gmstat.Checked = True Then
                gen.AppendLine("                GM = PlayerIsGM(Player)")
                gen.AppendLine("                If GM = 0")
                gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                gen.AppendLine("                    Output(Player, " + Chr(34) + "Unable to cast due to server authorization level." + Chr(34) + ")")
                gen.AppendLine("                    Return")
                gen.AppendLine("                EndIf")
            End If
            If frmEditor.race.Text = "" Then
            Else
                gen.AppendLine("                RaceReq# = " + frmEditor.race.Text)
                gen.AppendLine("                PlayerRace# = Race(Player)")
                gen.AppendLine("                If PlayerRace <> RaceReq")
                gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                gen.AppendLine("                    Output(Player, " + Chr(34) + "You're not the required race." + Chr(34) + ")")
                gen.AppendLine("                    Return")
                gen.AppendLine("                EndIf")
            End If
            If frmEditor.clss.Text = "" Then
            Else
                gen.AppendLine("                ClassReq# = " + frmEditor.clss.Text)
                gen.AppendLine("                PlayerClass# = Class(Player)")
                gen.AppendLine("                If PlayerClass <> ClassReq")
                gen.AppendLine("                    DeleteProgressBar(Player, CastBar)")
                gen.AppendLine("                    Output(Player, " + Chr(34) + "You're not the required class." + Chr(34) + ")")
                gen.AppendLine("                    Return")
                gen.AppendLine("                EndIf")
            End If
            If frmEditor.castAniName.Text = "" Then
            Else
                gen.AppendLine("                AnimateName = " + Chr(34) + frmEditor.castAniName.Text + Chr(34))
                gen.AppendLine("                AnimateSpeed = " + frmEditor.castAniSpeed.Text)
                gen.AppendLine("                AnimateActor(Player, AnimateName, AnimateSpeed)")
            End If
        End If
        'BEGINSPELL
        If frmEditor.cmbAniAfter.SelectedItem = "Target" Then
            If frmEditor.chkTarget.Checked = True Then
                gen.AppendLine("                AnimationName$ = " + Chr(34) + frmEditor.aniAfterName.Text + Chr(34))
                gen.AppendLine("                AnimationSpeed = " + frmEditor.aniAfterSpeed.Text)
                gen.AppendLine("                AnimateActor(Target, AnimationName, AnimationSpeed)")
            End If
        ElseIf frmEditor.cmbAniAfter.SelectedItem = "Player" Then
            gen.AppendLine("                AnimationName$ = " + Chr(34) + frmEditor.aniAfterName.Text + Chr(34))
            gen.AppendLine("                AnimationSpeed = " + frmEditor.aniAfterSpeed.Text)
            gen.AppendLine("                AnimateActor(Player, AnimationName, AnimationSpeed)")
        End If
        If frmEditor.textOutput.Text = "" Then
        Else
            gen.AppendLine("                TextOutput$ = " + Chr(34) + frmEditor.textOutput.Text + Chr(34))
            gen.AppendLine("                TextR# = " + frmEditor.textR.Text)
            gen.AppendLine("                TextG# = " + frmEditor.textG.Text)
            gen.AppendLine("                TextB# = " + frmEditor.textB.Text)
            gen.AppendLine("                AOETarget = NextActorInZone(Player)")
            gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
            gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
            If target = "Allies" Then
                gen.AppendLine("                    Output(Player, TextOutput, TextR, TextG, TextB)")
            Else
            End If
            gen.AppendLine("                If Player <> AOETarget")
            gen.AppendLine("                    Repeat")
            gen.AppendLine("                        If AOEDistance <= Range")
            If target = "Allies" Then
                gen.AppendLine("                            If CasterFaction = AOEFaction")
                gen.AppendLine("                                Output(AOETarget, TextOutput, TextR, TextG, TextB)")
                gen.AppendLine("                            End If")
            Else
                gen.AppendLine("                            If CasterFaction <> AOEFaction")
                gen.AppendLine("                                Output(AOETarget, TextOutput, TextR, TextG, TextB)")
                gen.AppendLine("                            End If")
            End If
            gen.AppendLine("                        EndIf")
            gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
            gen.AppendLine("                        AOETarget = NewTarget")
            gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
            gen.AppendLine("                        AOEDistance = ActorDistance(Player, AOETarget)")
            gen.AppendLine("                    Until Player = AOETarget")
            gen.AppendLine("                EndIf")
        End If
        If frmEditor.bubOut.Text = "" Then
        Else
            gen.AppendLine("                Text$ = " + Chr(34) + frmEditor.bubOut.Text + Chr(34))
            gen.AppendLine("                BubbleOutput(Player, Text, 255, 255, 255)")
        End If
        If frmEditor.cmbEmitter.SelectedItem = "Player" Then
            gen.AppendLine("                EmitterName$ = " + Chr(34) + frmEditor.emitterName.Text + Chr(34))
            gen.AppendLine("                TextureID# = " + frmEditor.emitterID.Text)
            gen.AppendLine("                Emittertime# = " + frmEditor.emitterLength.Text)
            If target = "Allies" Then
                gen.AppendLine("                CreateEmitter(Player, EmitterName, TextureID, Emittertime)")
            End If
        ElseIf frmEditor.cmbEmitter.SelectedItem = "Target" Then
            If frmEditor.chkTarget.Checked = True Then
                gen.AppendLine("                EmitterName$ = " + Chr(34) + frmEditor.emitterName.Text + Chr(34))
                gen.AppendLine("                TextureID# = " + frmEditor.emitterID.Text)
                gen.AppendLine("                Emittertime# = " + frmEditor.emitterLength.Text)
                gen.AppendLine("                CreateEmitter(Target, EmitterName, TextureID, Emittertime)")
            End If
        ElseIf frmEditor.cmbEmitter.SelectedItem = "AOE" Then
            gen.AppendLine("                EmitterName$ = " + Chr(34) + frmEditor.emitterName.Text + Chr(34))
            gen.AppendLine("                TextureID# = " + frmEditor.emitterID.Text)
            gen.AppendLine("                Emittertime# = " + frmEditor.emitterLength.Text)
            If target = "Allies" Then
                gen.AppendLine("                CreateEmitter(Player, EmitterName, TextureID, Emittertime)")
            End If
            gen.AppendLine("                AOETarget = NextActorInZone(Player)")
            gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
            gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
            gen.AppendLine("                If Player <> AOETarget")
            gen.AppendLine("                    Repeat")
            gen.AppendLine("                        If AOEDistance <= Range")
            If target = "Allies" Then
                gen.AppendLine("                            If AOEFaction = CasterFaction")
                gen.AppendLine("                                CreateEmitter(AOETarget, EmitterName, TextureID, Emittertime)")
                gen.AppendLine("                            End If")
            Else
                gen.AppendLine("                            If AOEFaction <> CasterFaction")
                gen.AppendLine("                                CreateEmitter(AOETarget, EmitterName, TextureID, Emittertime)")
                gen.AppendLine("                            End If")
            End If
            gen.AppendLine("                        EndIf")
            gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
            gen.AppendLine("                        AOETarget = NewTarget")
            gen.AppendLine("                        AOEDistance = ActorDistance(Player, AOETarget)")
            gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
            gen.AppendLine("                    Until Player = AOETarget")
            gen.AppendLine("                EndIf")
        End If
        If frmEditor.setname.Text = "" Then
        Else
            If frmEditor.chkTarget.Checked = True Then
                gen.AppendLine("                NewName$ = " + Chr(34) + frmEditor.setname.Text + Chr(34))
                gen.AppendLine("                SetName(Target, NewName)")
            End If
        End If
        If frmEditor.settag.Text = "" Then
        Else
            If frmEditor.chkTarget.Checked = True Then
                gen.AppendLine("                NewTag$ = " + Chr(34) + frmEditor.settag.Text + Chr(34))
                gen.AppendLine("                SetTag(Target, NewTag)")
            End If
        End If
        If frmEditor.sfID.Text = "" Then
        Else
            If frmEditor.chkTarget.Checked = True Then
                gen.AppendLine("                SFID# = " + frmEditor.sfID.Text)
                gen.AppendLine("                SFLength# = " + frmEditor.sfLength.Text)
                gen.AppendLine("                SFAlpha# = " + frmEditor.sfAlpha.Text)
                gen.AppendLine("                SFR# = " + frmEditor.sfR.Text)
                gen.AppendLine("                SFG# = " + frmEditor.sfG.Text)
                gen.AppendLine("                SFB# = " + frmEditor.sfB.Text)
                gen.AppendLine("                ScreenFlash(Target, SFR, SFG, SFB, SFAlpha, SFLength, SFID)")
            End If
        End If
        If frmEditor.Zone.Text = "" Then
        Else
            If frmEditor.chkTarget.Checked = True Then
                gen.AppendLine("                Zone = " + Chr(34) + frmEditor.Zone.Text + Chr(34))
                gen.AppendLine("                WayPoint = " + Chr(34) + frmEditor.wpZone.Text + Chr(34))
                gen.AppendLine("                Warp(Target, Zone, WayPoint)")
            End If
        End If
        If frmEditor.hfTitle.Text = "" Then
        Else
            If frmEditor.chkTarget.Checked = True Then
                gen.AppendLine("                FactionTitle = " + Chr(34) + frmEditor.hfTitle.Text + Chr(34))
                gen.AppendLine("                SetHomeFaction(Target, FactionTitle)")
            End If
        End If
        If frmEditor.proName.Text = "" Then
        Else
            If frmEditor.chkTarget.Checked = True Then
                gen.AppendLine("                ProjectileName = " + Chr(34) + frmEditor.proName.Text + Chr(34))
                gen.AppendLine("                FireProjectile(Player, Target, ProjectileName)")
            End If
        End If
        If frmEditor.chkTarget.Checked = True Then
            If frmEditor.ai.Text = "0 - Wait in current position, attack any valid targets who come into range" Then
                gen.AppendLine("                SetActorAIState(Target, 0)")
            ElseIf frmEditor.ai.Text = "1 - Patrol - walk to destination, then set destination to new waypoint if available" Then
                gen.AppendLine("                SetActorAIState(Target, 1)")
            ElseIf frmEditor.ai.Text = "2 - Run - same as Patrol but running instead of walking" Then
                gen.AppendLine("                SetActorAIState(Target, 2)")
            ElseIf frmEditor.ai.Text = "3 - Chase and attack target" Then
                gen.AppendLine("                SetActorAIState(Target, 3)")
            ElseIf frmEditor.ai.Text = "4 - For actors who are paused at a waypoint While on patrol" Then
                gen.AppendLine("                SetActorAIState(Target, 4)")
            ElseIf frmEditor.ai.Text = "5 - Pet mode - actor will follow leader and attack leader's target (actor MUST have a leader to use this)" Then
                gen.AppendLine("                SetActorAIState(Target, 5)")
            ElseIf frmEditor.ai.Text = "6 - Pet attack mode - actor is chasing and attacking the leader's target" Then
                gen.AppendLine("                SetActorAIState(Target, 6)")
            ElseIf frmEditor.ai.Text = "7 - Pet wait mode - actor waits in current position and does absolutely nothing" Then
                gen.AppendLine("                SetActorAIState(Target, 7)")
            End If
        End If
        If frmEditor.desX.Text = "" Then
        Else
            If frmEditor.chkTarget.Checked = True Then
                gen.AppendLine("                DesX# = " + frmEditor.desX.Text)
                gen.AppendLine("                DesZ# = " + frmEditor.desZ.Text)
                gen.AppendLine("                SetActorDestination(Target, DesX, DesZ)")
            End If
        End If
        If frmEditor.lv.Text = "" Then
        Else
            If frmEditor.chkTarget.Checked = True Then
                gen.AppendLine("                NewLevel = " + frmEditor.lv.Text)
                gen.AppendLine("                SetActorLevel(Target, NewLevel)")
            End If
        End If
        If frmEditor.rep.Text = "" Then
        Else
            If frmEditor.chkTarget.Checked = True Then
                gen.AppendLine("                Rep = Reputation(Target)")
                gen.AppendLine("                SetRep = " + frmEditor.rep.Text)
                gen.AppendLine("                NewRep = Rep + SetRep")
                gen.AppendLine("                SetReputation(Target, NewRep)")
            End If
        End If
        'set hair
        If frmEditor.chkTarget.Checked = True Then
            If frmEditor.visHair.Text = "1" Then
                gen.AppendLine("                SetActorHair(Target, 1)")
            ElseIf frmEditor.visHair.Text = "2" Then
                gen.AppendLine("                SetActorHair(Target, 2)")
            ElseIf frmEditor.visHair.Text = "3" Then
                gen.AppendLine("                SetActorHair(Target, 3)")
            ElseIf frmEditor.visHair.Text = "4" Then
                gen.AppendLine("                SetActorHair(Target, 4)")
            ElseIf frmEditor.visHair.Text = "5" Then
                gen.AppendLine("                SetActorHair(Target, 5)")
            End If
            'set beard
            If frmEditor.visBeard.Text = "1" Then
                gen.AppendLine("                SetActorBeard(Target, 1)")
            ElseIf frmEditor.visBeard.Text = "2" Then
                gen.AppendLine("                SetActorBeard(Target, 2)")
            ElseIf frmEditor.visBeard.Text = "3" Then
                gen.AppendLine("                SetActorBeard(Target, 3)")
            ElseIf frmEditor.visBeard.Text = "4" Then
                gen.AppendLine("                SetActorBeard(Target, 4)")
            ElseIf frmEditor.visBeard.Text = "5" Then
                gen.AppendLine("                SetActorBeard(Target, 5)")
            End If
            'set face
            If frmEditor.visFace.Text = "1" Then
                gen.AppendLine("                SetActorFace(Target, 1)")
            ElseIf frmEditor.visFace.Text = "2" Then
                gen.AppendLine("                SetActorFace(Target, 2)")
            ElseIf frmEditor.visFace.Text = "3" Then
                gen.AppendLine("                SetActorFace(Target, 3)")
            ElseIf frmEditor.visFace.Text = "4" Then
                gen.AppendLine("                SetActorFace(Target, 4)")
            ElseIf frmEditor.visFace.Text = "5" Then
                gen.AppendLine("                SetActorFace(Target, 5)")
            End If
            'set clothes
            If frmEditor.visClothes.Text = "1" Then
                gen.AppendLine("                SetActorClothes(Target, 1)")
            ElseIf frmEditor.visClothes.Text = "2" Then
                gen.AppendLine("                SetActorClothes(Target, 2)")
            ElseIf frmEditor.visClothes.Text = "3" Then
                gen.AppendLine("                SetActorClothes(Target, 3)")
            ElseIf frmEditor.visClothes.Text = "4" Then
                gen.AppendLine("                SetActorClothes(Target, 4)")
            ElseIf frmEditor.visClothes.Text = "5" Then
                gen.AppendLine("                SetActorClothes(Target, 5)")
            End If
            'set gender
            If frmEditor.visGender.Text = "Male" Then
                gen.AppendLine("                SetActorGender(Target, 1)")
            ElseIf frmEditor.visGender.Text = "Female" Then
                gen.AppendLine("                SetActorGender(Target, 2)")
            End If
        End If
        If frmEditor.teScript.Text = "" Then
        Else
            If frmEditor.chkTarget.Checked = True Then
                gen.AppendLine("                Script$ = " + Chr(34) + frmEditor.teScript.Text + Chr(34))
                gen.AppendLine("                ScriptFunction$ = " + Chr(34) + frmEditor.teFunction.Text + Chr(34))
                gen.AppendLine("                ThreadExecute(Script, ScriptFunction, Player, Target)")
            Else
                gen.AppendLine("                Script$ = " + Chr(34) + frmEditor.teScript.Text + Chr(34))
                gen.AppendLine("                ScriptFunction$ = " + Chr(34) + frmEditor.teFunction.Text + Chr(34))
                gen.AppendLine("                ThreadExecute(Script, ScriptFunction, Player")
            End If
        End If
        If frmEditor.soID.Text = "" Then
        Else
            gen.AppendLine("                SoundID# = " + frmEditor.soID.Text)
            gen.AppendLine("                PlaySound(Player, SoundID, 0)")
            gen.AppendLine("                AOETarget = NextActorInZone(Player)")
            If frmEditor.chkTarget.Checked = True Then
                gen.AppendLine("                SoundDistance = ActorDistance(Target, AOETarget)")
            Else
                gen.AppendLine("                SoundDistance = ActorDistance(Player, AOETarget)")
            End If
            gen.AppendLine("                If Player <> AOETarget")
            gen.AppendLine("                    Repeat")
            gen.AppendLine("                        If SoundDistance <= Range")
            gen.AppendLine("                            PlaySound(AOETarget, SoundID, 0)")
            gen.AppendLine("                        EndIf")
            gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
            gen.AppendLine("                        AOETarget = NewTarget")
            If frmEditor.chkTarget.Checked = True Then
                gen.AppendLine("                        SoundDistance = ActorDistance(Target, AOETarget)")
            Else
                gen.AppendLine("                        SoundDistance = ActorDistance(Player, AOETarget)")
            End If
            gen.AppendLine("                    Until Player = AOETarget")
            gen.AppendLine("                EndIf")
        End If
        If frmEditor.xp.Text = "" Then
        Else
            If frmEditor.chkTarget.Checked = True Then
                gen.AppendLine("                EXP# = " + frmEditor.xp.Text)
                gen.AppendLine("                GiveXP(Target, EXP, 1)")
            End If
        End If
        If frmEditor.chkTarget.Checked = True Then
            'set resist 1
            If frmEditor.reN1.Text = "" Then
            Else
                gen.AppendLine("                Resist$ = " + Chr(34) + frmEditor.reN1.Text + Chr(34))
                gen.AppendLine("                NewResist# = " + frmEditor.reA1.Text)
                gen.AppendLine("                CurrentResist# = Resistance(Target, Resist)")
                gen.AppendLine("                Value = NewResist + CurrentResist")
                gen.AppendLine("                SetResistance(Target, Resist, Value)")
            End If
            'set resist 2
            If frmEditor.reN2.Text = "" Then
            Else
                gen.AppendLine("                Resist$ = " + Chr(34) + frmEditor.reN2.Text + Chr(34))
                gen.AppendLine("                NewResist# = " + frmEditor.reA2.Text)
                gen.AppendLine("                Value = NewResist + CurrentResist")
                gen.AppendLine("                SetResistance(Target, Resist, Value)")
            End If
            'set resist 3
            If frmEditor.reN3.Text = "" Then
            Else
                gen.AppendLine("                Resist$ = " + Chr(34) + frmEditor.reN3.Text + Chr(34))
                gen.AppendLine("                NewResist# = " + frmEditor.reA3.Text)
                gen.AppendLine("                Value = NewResist + CurrentResist")
                gen.AppendLine("                SetResistance(Target, Resist, Value)")
            End If
            'set resist 4
            If frmEditor.reN4.Text = "" Then
            Else
                gen.AppendLine("                Resist$ = " + Chr(34) + frmEditor.reN4.Text + Chr(34))
                gen.AppendLine("                NewResist# = " + frmEditor.reA4.Text)
                gen.AppendLine("                Value = NewResist + CurrentResist")
                gen.AppendLine("                SetResistance(Target, Resist, Value)")
            End If
            'set resist 5
            If frmEditor.reN5.Text = "" Then
            Else
                gen.AppendLine("                Resist$ = " + Chr(34) + frmEditor.reN5.Text + Chr(34))
                gen.AppendLine("                NewResist# = " + frmEditor.reA5.Text)
                gen.AppendLine("                Value = NewResist + CurrentResist")
                gen.AppendLine("                SetResistance(Target, Resist, Value)")
            End If
            'set resist 6
            If frmEditor.reN6.Text = "" Then
            Else
                gen.AppendLine("                Resist$ = " + Chr(34) + frmEditor.reN6.Text + Chr(34))
                gen.AppendLine("                NewResist# = " + frmEditor.reA6.Text)
                gen.AppendLine("                Value = NewResist + CurrentResist")
                gen.AppendLine("                SetResistance(Target, Resist, Value)")
            End If
            'set resist 7
            If frmEditor.reN7.Text = "" Then
            Else
                gen.AppendLine("                Resist$ = " + Chr(34) + frmEditor.reN7.Text + Chr(34))
                gen.AppendLine("                NewResist# = " + frmEditor.reA7.Text)
                gen.AppendLine("                Value = NewResist + CurrentResist")
                gen.AppendLine("                SetResistance(Target, Resist, Value)")
            End If
            'set resist 8
            If frmEditor.reN8.Text = "" Then
            Else
                gen.AppendLine("                Resist# = " + Chr(34) + frmEditor.reN8.Text + Chr(34))
                gen.AppendLine("                NewResist# = " + frmEditor.reA8.Text)
                gen.AppendLine("                Value = NewResist + CurrentResist")
                gen.AppendLine("                SetResistance(Target, Resist, Value)")
            End If
            'set resist 9
            If frmEditor.reN9.Text = "" Then
            Else
                gen.AppendLine("                Resist$ = " + Chr(34) + frmEditor.reN9.Text + Chr(34))
                gen.AppendLine("                NewResist# = " + frmEditor.reA9.Text)
                gen.AppendLine("                Value = NewResist + CurrentResist")
                gen.AppendLine("                SetResistance(Target, Resist, Value)")
            End If
            'set resist 10
            If frmEditor.reN10.Text = "" Then
            Else
                gen.AppendLine("                Resist$ = " + Chr(34) + frmEditor.reN10.Text + Chr(34))
                gen.AppendLine("                NewResist# = " + frmEditor.reA10.Text)
                gen.AppendLine("                Value = NewResist + CurrentResist")
                gen.AppendLine("                SetResistance(Target, Resist, Value)")
            End If
            'set resist 11
            If frmEditor.reN11.Text = "" Then
            Else
                gen.AppendLine("                Resist$ = " + Chr(34) + frmEditor.reN11.Text + Chr(34))
                gen.AppendLine("                NewResist# = " + frmEditor.reA11.Text)
                gen.AppendLine("                Value = NewResist + CurrentResist")
                gen.AppendLine("                SetResistance(Target, Resist, Value)")
            End If
            'set resist 12
            If frmEditor.reN12.Text = "" Then
            Else
                gen.AppendLine("                Resist$ = " + Chr(34) + frmEditor.reN12.Text + Chr(34))
                gen.AppendLine("                NewResist# = " + frmEditor.reA12.Text)
                gen.AppendLine("                Value = NewResist + CurrentResist")
                gen.AppendLine("                SetResistance(Target, Resist, Value)")
            End If
            'set resist 13
            If frmEditor.reN13.Text = "" Then
            Else
                gen.AppendLine("                Resist$ = " + Chr(34) + frmEditor.reN13.Text + Chr(34))
                gen.AppendLine("                NewResist# = " + frmEditor.reA13.Text)
                gen.AppendLine("                Value = NewResist + CurrentResist")
                gen.AppendLine("                SetResistance(Target, Resist, Value)")
            End If
            'set resist 14
            If frmEditor.reN14.Text = "" Then
            Else
                gen.AppendLine("                Resist$ = " + Chr(34) + frmEditor.reN14.Text + Chr(34))
                gen.AppendLine("                NewResist# = " + frmEditor.reA14.Text)
                gen.AppendLine("                Value = NewResist + CurrentResist")
                gen.AppendLine("                SetResistance(Target, Resist, Value)")
            End If
            'set resist 15
            If frmEditor.reN15.Text = "" Then
            Else
                gen.AppendLine("                Resist$ = " + Chr(34) + frmEditor.reN15.Text + Chr(34))
                gen.AppendLine("                NewResist# = " + frmEditor.reA15.Text)
                gen.AppendLine("                Value = NewResist + CurrentResist")
                gen.AppendLine("                SetResistance(Target, Resist, Value)")
            End If
            'set resist 16
            If frmEditor.reN16.Text = "" Then
            Else
                gen.AppendLine("                Resist$ = " + Chr(34) + frmEditor.reN16.Text + Chr(34))
                gen.AppendLine("                NewResist# = " + frmEditor.reA16.Text)
                gen.AppendLine("                Value = NewResist + CurrentResist")
                gen.AppendLine("                SetResistance(Target, Resist, Value)")
            End If
        End If

        If frmEditor.bfT1.Text = "Self" Then
            gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN1.Text + Chr(34))
            If frmEditor.bfA1.Checked = True Then
                gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN1.Text + Chr(34))
                gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM1.Text)
                gen.AppendLine("                BuffLength# = " + frmEditor.bfL1.Text)
                gen.AppendLine("                BuffID# = " + frmEditor.bfID1.Text)
                gen.AppendLine("                TotalBuff# = BuffAmount + Attribute(Player, BuffAttribute)")
                gen.AppendLine("                If TotalBuff < 0")
                gen.AppendLine("                    Repeat")
                gen.AppendLine("                        TotalBuff = TotalBuff + 1")
                gen.AppendLine("                    Until TotalBuff = 0")
                gen.AppendLine("                    AddActorEffect(Player, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                gen.AppendLine("                Else")
                gen.AppendLine("                    AddActorEffect(Player, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                gen.AppendLine("                EndIf")
            Else
                gen.AppendLine("                DeleteActorEffect(Player, BuffName)")
            End If
        ElseIf frmEditor.bfT1.Text = "Target" Then
            If frmEditor.chkTarget.Checked = True Then
                gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN1.Text + Chr(34))
                If frmEditor.bfA1.Checked = True Then
                    gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN1.Text + Chr(34))
                    gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM1.Text)
                    gen.AppendLine("                BuffLength# = " + frmEditor.bfL1.Text)
                    gen.AppendLine("                BuffID# = " + frmEditor.bfID1.Text)
                    gen.AppendLine("                TotalBuff# = BuffAmount + Attribute(Target, BuffAttribute)")
                    gen.AppendLine("                If TotalBuff < 0")
                    gen.AppendLine("                    Repeat")
                    gen.AppendLine("                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                    Until TotalBuff = 0")
                    gen.AppendLine("                    AddActorEffect(Target, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    AddActorEffect(Target, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                EndIf")
                Else
                    gen.AppendLine("                DeleteActorEffect(Target, BuffName)")
                End If
            End If
        ElseIf frmEditor.bfT1.Text = "AOE" Then 'RETURNTOME
            gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN1.Text + Chr(34))
            If frmEditor.bfA1.Checked = True Then
                gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN1.Text + Chr(34))
                gen.AppendLine("                BuffLength# = " + frmEditor.bfL1.Text)
                gen.AppendLine("                BuffID# = " + frmEditor.bfID1.Text)
                gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM1.Text)
                If target = "Allies" Then
                    gen.AppendLine("                AddActorEffect(Player, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                End If
                gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                If Player <> AOETarget")
                gen.AppendLine("                    Repeat")
                gen.AppendLine("                        If AOEDistance <= Range")
                If target = "Allies" Then
                    gen.AppendLine("                            If AOEFaction = CasterFaction")
                    gen.AppendLine("                                TotalBuff# = BuffAmount + Attribute(Player, BuffAttribute)")
                    gen.AppendLine("                                If TotalBuff < 0")
                    gen.AppendLine("                                    Repeat")
                    gen.AppendLine("                                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                                    Until TotalBuff = 0")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                                Else")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                            EndIf")
                Else
                    gen.AppendLine("                            If AOEFaction <> CasterFaction")
                    gen.AppendLine("                                TotalBuff# = BuffAmount + Attribute(Player, BuffAttribute)")
                    gen.AppendLine("                                If TotalBuff < 0")
                    gen.AppendLine("                                    Repeat")
                    gen.AppendLine("                                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                                    Until TotalBuff = 0")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                                Else")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                            EndIf")
                End If
                gen.AppendLine("                        EndIf")
                gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                gen.AppendLine("                        AOETarget = NewTarget")
                gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                        AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                    Until Player = AOETarget")
                gen.AppendLine("                EndIf")
            Else
                gen.AppendLine("                AOETarget = NextActorInZone(Player)") 'savepoint
                gen.AppendLine("                AOEFaction = HomeFaction(AOETarget)")
                gen.AppendLine("                AOEDistance = Actordistance(Player, AOETarget)")
                If target = "Allies" Then
                    gen.AppendLine("                DeleteActorEffect(Player, BuffName)")
                End If
                gen.AppendLine("                If Player <> AOETarget")
                gen.AppendLine("                    Repeat")
                gen.AppendLine("                        AOEFaction = HomeFaction(AOETarget)")
                gen.AppendLine("                        If AOEDistance <= Range")
                gen.AppendLine("                            If AOEFaction = CasterFaction")
                gen.AppendLine("                                    DeleteActorEffect(AOETarget, BuffName)")
                gen.AppendLine("                            EndIf")
                gen.AppendLine("                        EndIf")
                gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                gen.AppendLine("                        AOETarget = NewTarget")
                gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                        AOEDistance = Actordistance(Player, AOETarget)")
                gen.AppendLine("                    Until Player = AOETarget")
                gen.AppendLine("                EndIf")
            End If
        End If
            If frmEditor.bft2.Text = "Self" Then
                gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN2.Text + Chr(34))
                If frmEditor.bfA2.Checked = True Then
                    gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN2.Text + Chr(34))
                    gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM2.Text)
                    gen.AppendLine("                BuffLength# = " + frmEditor.bfL2.Text)
                    gen.AppendLine("                BuffID# = " + frmEditor.bfID2.Text)
                    gen.AppendLine("                AddActorEffect(Player, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                Else
                    gen.AppendLine("                DeleteActorEffect(Player, BuffName)")
                End If
        ElseIf frmEditor.bft2.Text = "Target" Then
            If frmEditor.chkTarget.Checked = True Then
                gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN2.Text + Chr(34))
                If frmEditor.bfA2.Checked = True Then
                    gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN2.Text + Chr(34))
                    gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM2.Text)
                    gen.AppendLine("                BuffLength# = " + frmEditor.bfL2.Text)
                    gen.AppendLine("                BuffID# = " + frmEditor.bfID2.Text)
                    gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN1.Text + Chr(34))
                    gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM1.Text)
                    gen.AppendLine("                BuffLength# = " + frmEditor.bfL1.Text)
                    gen.AppendLine("                BuffID# = " + frmEditor.bfID1.Text)
                    gen.AppendLine("                TotalBuff# = BuffAmount + Attribute(Target, BuffAttribute)")
                    gen.AppendLine("                If TotalBuff < 0")
                    gen.AppendLine("                    Repeat")
                    gen.AppendLine("                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                    Until TotalBuff = 0")
                    gen.AppendLine("                    AddActorEffect(Target, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    AddActorEffect(Target, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                EndIf")
                Else
                    gen.AppendLine("                DeleteActorEffect(Target, BuffName)")
                End If
            End If
        ElseIf frmEditor.bft2.Text = "AOE" Then
            gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN2.Text + Chr(34))
            If frmEditor.bfA2.Checked = True Then
                gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN2.Text + Chr(34))
                gen.AppendLine("                BuffLength# = " + frmEditor.bfL2.Text)
                gen.AppendLine("                BuffID# = " + frmEditor.bfID2.Text)
                gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM2.Text)
                If target = "Allies" Then
                    gen.AppendLine("                AddActorEffect(Player, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                End If
                gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                AOEFaction = HomeFaction(AOETarget)")
                gen.AppendLine("                If Player <> AOETarget")
                gen.AppendLine("                    Repeat")
                gen.AppendLine("                        If AOEDistance <= Range")
                If target = "Allies" Then
                    gen.AppendLine("                            If AOEFaction = CasterFaction")
                    gen.AppendLine("                                TotalBuff# = BuffAmount + Attribute(Player, BuffAttribute)")
                    gen.AppendLine("                                If TotalBuff < 0")
                    gen.AppendLine("                                    Repeat")
                    gen.AppendLine("                                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                                    Until TotalBuff = 0")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                                Else")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                            EndIf")
                Else
                    gen.AppendLine("                            If AOEFaction <> CasterFaction")
                    gen.AppendLine("                                TotalBuff# = BuffAmount + Attribute(Player, BuffAttribute)")
                    gen.AppendLine("                                If TotalBuff < 0")
                    gen.AppendLine("                                    Repeat")
                    gen.AppendLine("                                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                                    Until TotalBuff = 0")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                                Else")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                            EndIf")
                End If
                gen.AppendLine("                        EndIf")
                gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                gen.AppendLine("                        AOETarget = NewTarget")
                gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                        AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                    Until Player = AOETarget")
                gen.AppendLine("                EndIf")
            Else
                gen.AppendLine("                AOETarget = NextActorInZone(Player)") 'savepoint
                gen.AppendLine("                AOEFaction = HomeFaction(AOETarget)")
                gen.AppendLine("                AOEDistance = Actordistance(Player, AOETarget)")
                If target = "Allies" Then
                    gen.AppendLine("                DeleteActorEffect(Player, BuffName)")
                End If
                gen.AppendLine("                If Player <> AOETarget")
                gen.AppendLine("                    Repeat")
                gen.AppendLine("                        AOEFaction = HomeFaction(AOETarget)")
                gen.AppendLine("                        If AOEDistance <= Range")
                gen.AppendLine("                            If AOEFaction = CasterFaction")
                gen.AppendLine("                                    DeleteActorEffect(AOETarget, BuffName)")
                gen.AppendLine("                            EndIf")
                gen.AppendLine("                        EndIf")
                gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                gen.AppendLine("                        AOETarget = NewTarget")
                gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                        AOEDistance = Actordistance(Player, AOETarget)")
                gen.AppendLine("                    Until Player = AOETarget")
                gen.AppendLine("                EndIf")
            End If
        End If
        If frmEditor.bft3.Text = "Self" Then
            gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN3.Text + Chr(34))
            If frmEditor.bfA3.Checked = True Then
                gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN3.Text + Chr(34))
                gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM3.Text)
                gen.AppendLine("                BuffLength# = " + frmEditor.bfL3.Text)
                gen.AppendLine("                BuffID# = " + frmEditor.bfID3.Text)
                gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN1.Text + Chr(34))
                gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM1.Text)
                gen.AppendLine("                BuffLength# = " + frmEditor.bfL1.Text)
                gen.AppendLine("                BuffID# = " + frmEditor.bfID1.Text)
                gen.AppendLine("                TotalBuff# = BuffAmount + Attribute(Player, BuffAttribute)")
                gen.AppendLine("                If TotalBuff < 0")
                gen.AppendLine("                    Repeat")
                gen.AppendLine("                        TotalBuff = TotalBuff + 1")
                gen.AppendLine("                    Until TotalBuff = 0")
                gen.AppendLine("                    AddActorEffect(Player, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                gen.AppendLine("                Else")
                gen.AppendLine("                    AddActorEffect(Player, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                gen.AppendLine("                EndIf")
            Else
                gen.AppendLine("                DeleteActorEffect(Player, BuffName)")
            End If
        ElseIf frmEditor.bft3.Text = "Target" Then
            If frmEditor.chkTarget.Checked = True Then
                gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN3.Text + Chr(34))
                If frmEditor.bfA3.Checked = True Then
                    gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN3.Text + Chr(34))
                    gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM3.Text)
                    gen.AppendLine("                BuffLength# = " + frmEditor.bfL3.Text)
                    gen.AppendLine("                BuffID# = " + frmEditor.bfID3.Text)
                    gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN1.Text + Chr(34))
                    gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM1.Text)
                    gen.AppendLine("                BuffLength# = " + frmEditor.bfL1.Text)
                    gen.AppendLine("                BuffID# = " + frmEditor.bfID1.Text)
                    gen.AppendLine("                TotalBuff# = BuffAmount + Attribute(Target, BuffAttribute)")
                    gen.AppendLine("                If TotalBuff < 0")
                    gen.AppendLine("                    Repeat")
                    gen.AppendLine("                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                    Until TotalBuff = 0")
                    gen.AppendLine("                    AddActorEffect(Target, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    AddActorEffect(Target, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                EndIf")
                Else
                    gen.AppendLine("                DeleteActorEffect(Target, BuffName)")
                End If
            End If

        ElseIf frmEditor.bft3.Text = "AOE" Then
            gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN3.Text + Chr(34))
            If frmEditor.bfA3.Checked = True Then
                gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN3.Text + Chr(34))
                gen.AppendLine("                BuffLength# = " + frmEditor.bfL3.Text)
                gen.AppendLine("                BuffID# = " + frmEditor.bfID3.Text)
                gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM3.Text)
                If target = "Allies" Then
                    gen.AppendLine("                AddActorEffect(Player, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                End If
                gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                AOEFaction = HomeFaction(AOETarget)")
                gen.AppendLine("                If Player <> AOETarget")
                gen.AppendLine("                    Repeat")
                gen.AppendLine("                        If AOEDistance <= Range")
                If target = "Allies" Then
                    gen.AppendLine("                            If AOEFaction = CasterFaction")
                    gen.AppendLine("                                TotalBuff# = BuffAmount + Attribute(Player, BuffAttribute)")
                    gen.AppendLine("                                If TotalBuff < 0")
                    gen.AppendLine("                                    Repeat")
                    gen.AppendLine("                                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                                    Until TotalBuff = 0")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                                Else")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                            EndIf")
                Else
                    gen.AppendLine("                            If AOEFaction <> CasterFaction")
                    gen.AppendLine("                                TotalBuff# = BuffAmount + Attribute(Player, BuffAttribute)")
                    gen.AppendLine("                                If TotalBuff < 0")
                    gen.AppendLine("                                    Repeat")
                    gen.AppendLine("                                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                                    Until TotalBuff = 0")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                                Else")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                            EndIf")
                End If
                gen.AppendLine("                        EndIf")
                gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                gen.AppendLine("                        AOETarget = NewTarget")
                gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                        AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                    Until Player = AOETarget")
                gen.AppendLine("                EndIf")
            Else
                gen.AppendLine("                AOETarget = NextActorInZone(Player)") 'savepoint
                gen.AppendLine("                AOEFaction = HomeFaction(AOETarget)")
                gen.AppendLine("                AOEDistance = Actordistance(Player, AOETarget)")
                If target = "Allies" Then
                    gen.AppendLine("                DeleteActorEffect(Player, BuffName)")
                End If
                gen.AppendLine("                If Player <> AOETarget")
                gen.AppendLine("                    Repeat")
                gen.AppendLine("                        AOEFaction = HomeFaction(AOETarget)")
                gen.AppendLine("                        If AOEDistance <= Range")
                gen.AppendLine("                            If AOEFaction = CasterFaction")
                gen.AppendLine("                                    DeleteActorEffect(AOETarget, BuffName)")
                gen.AppendLine("                            EndIf")
                gen.AppendLine("                        EndIf")
                gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                gen.AppendLine("                        AOETarget = NewTarget")
                gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                        AOEDistance = Actordistance(Player, AOETarget)")
                gen.AppendLine("                    Until Player = AOETarget")
                gen.AppendLine("                EndIf")
            End If
        End If
        If frmEditor.bft4.Text = "Self" Then
            gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN4.Text + Chr(34))
            If frmEditor.bfA4.Checked = True Then
                gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN4.Text + Chr(34))
                gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM4.Text)
                gen.AppendLine("                BuffLength# = " + frmEditor.bfL4.Text)
                gen.AppendLine("                BuffID# = " + frmEditor.bfID4.Text)
                gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN1.Text + Chr(34))
                gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM1.Text)
                gen.AppendLine("                BuffLength# = " + frmEditor.bfL1.Text)
                gen.AppendLine("                BuffID# = " + frmEditor.bfID1.Text)
                gen.AppendLine("                TotalBuff# = BuffAmount + Attribute(Player, BuffAttribute)")
                gen.AppendLine("                If TotalBuff < 0")
                gen.AppendLine("                    Repeat")
                gen.AppendLine("                        TotalBuff = TotalBuff + 1")
                gen.AppendLine("                    Until TotalBuff = 0")
                gen.AppendLine("                    AddActorEffect(Player, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                gen.AppendLine("                Else")
                gen.AppendLine("                    AddActorEffect(Player, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                gen.AppendLine("                EndIf")
            Else
                gen.AppendLine("                DeleteActorEffect(Player, BuffName)")
            End If
        ElseIf frmEditor.bft4.Text = "Target" Then
            If frmEditor.chkTarget.Checked = True Then
                gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN4.Text + Chr(34))
                If frmEditor.bfA4.Checked = True Then
                    gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN4.Text + Chr(34))
                    gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM4.Text)
                    gen.AppendLine("                BuffLength# = " + frmEditor.bfL4.Text)
                    gen.AppendLine("                BuffID# = " + frmEditor.bfID4.Text)
                    gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN1.Text + Chr(34))
                    gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM1.Text)
                    gen.AppendLine("                BuffLength# = " + frmEditor.bfL1.Text)
                    gen.AppendLine("                BuffID# = " + frmEditor.bfID1.Text)
                    gen.AppendLine("                TotalBuff# = BuffAmount + Attribute(Target, BuffAttribute)")
                    gen.AppendLine("                If TotalBuff < 0")
                    gen.AppendLine("                    Repeat")
                    gen.AppendLine("                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                    Until TotalBuff = 0")
                    gen.AppendLine("                    AddActorEffect(Target, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    AddActorEffect(Target, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                EndIf")
                Else
                    gen.AppendLine("                DeleteActorEffect(Target, BuffName)")
                End If
            End If
        ElseIf frmEditor.bft4.Text = "AOE" Then
            gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN4.Text + Chr(34))
            If frmEditor.bfA4.Checked = True Then
                gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN4.Text + Chr(34))
                gen.AppendLine("                BuffLength# = " + frmEditor.bfL4.Text)
                gen.AppendLine("                BuffID# = " + frmEditor.bfID4.Text)
                gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM4.Text)
                If target = "Allies" Then
                    gen.AppendLine("                AddActorEffect(Player, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                End If
                gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                AOEFaction = HomeFaction(AOETarget)")
                gen.AppendLine("                If Player <> AOETarget")
                gen.AppendLine("                    Repeat")
                gen.AppendLine("                        If AOEDistance <= Range")
                If target = "Allies" Then
                    gen.AppendLine("                            If AOEFaction = CasterFaction")
                    gen.AppendLine("                                TotalBuff# = BuffAmount + Attribute(Player, BuffAttribute)")
                    gen.AppendLine("                                If TotalBuff < 0")
                    gen.AppendLine("                                    Repeat")
                    gen.AppendLine("                                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                                    Until TotalBuff = 0")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                                Else")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                            EndIf")
                Else
                    gen.AppendLine("                            If AOEFaction <> CasterFaction")
                    gen.AppendLine("                                TotalBuff# = BuffAmount + Attribute(Player, BuffAttribute)")
                    gen.AppendLine("                                If TotalBuff < 0")
                    gen.AppendLine("                                    Repeat")
                    gen.AppendLine("                                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                                    Until TotalBuff = 0")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                                Else")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                            EndIf")
                End If
                gen.AppendLine("                        EndIf")
                gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                gen.AppendLine("                        AOETarget = NewTarget")
                gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                        AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                    Until Player = AOETarget")
                gen.AppendLine("                EndIf")
            Else
                gen.AppendLine("                AOETarget = NextActorInZone(Player)") 'savepoint
                gen.AppendLine("                AOEFaction = HomeFaction(AOETarget)")
                gen.AppendLine("                AOEDistance = Actordistance(Player, AOETarget)")
                If target = "Allies" Then
                    gen.AppendLine("                DeleteActorEffect(Player, BuffName)")
                End If
                gen.AppendLine("                If Player <> AOETarget")
                gen.AppendLine("                    Repeat")
                gen.AppendLine("                        AOEFaction = HomeFaction(AOETarget)")
                gen.AppendLine("                        If AOEDistance <= Range")
                gen.AppendLine("                            If AOEFaction = CasterFaction")
                gen.AppendLine("                                    DeleteActorEffect(AOETarget, BuffName)")
                gen.AppendLine("                            EndIf")
                gen.AppendLine("                        EndIf")
                gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                gen.AppendLine("                        AOETarget = NewTarget")
                gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                        AOEDistance = Actordistance(Player, AOETarget)")
                gen.AppendLine("                    Until Player = AOETarget")
                gen.AppendLine("                EndIf")
            End If
        End If
        If frmEditor.bft5.Text = "Self" Then
            gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN5.Text + Chr(34))
            If frmEditor.bfA5.Checked = True Then
                gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN5.Text + Chr(34))
                gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM5.Text)
                gen.AppendLine("                BuffLength# = " + frmEditor.bfL5.Text)
                gen.AppendLine("                BuffID# = " + frmEditor.bfID5.Text)
                gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN1.Text + Chr(34))
                gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM1.Text)
                gen.AppendLine("                BuffLength# = " + frmEditor.bfL1.Text)
                gen.AppendLine("                BuffID# = " + frmEditor.bfID1.Text)
                gen.AppendLine("                TotalBuff# = BuffAmount + Attribute(Player, BuffAttribute)")
                gen.AppendLine("                If TotalBuff < 0")
                gen.AppendLine("                    Repeat")
                gen.AppendLine("                        TotalBuff = TotalBuff + 1")
                gen.AppendLine("                    Until TotalBuff = 0")
                gen.AppendLine("                    AddActorEffect(Player, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                gen.AppendLine("                Else")
                gen.AppendLine("                    AddActorEffect(Player, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                gen.AppendLine("                EndIf")
            Else
                gen.AppendLine("                DeleteActorEffect(Player, BuffName)")
            End If
        ElseIf frmEditor.bft5.Text = "Target" Then
            If frmEditor.chkTarget.Checked = True Then
                gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN5.Text + Chr(34))
                If frmEditor.bfA5.Checked = True Then
                    gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN5.Text + Chr(34))
                    gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM5.Text)
                    gen.AppendLine("                BuffLength# = " + frmEditor.bfL5.Text)
                    gen.AppendLine("                BuffID# = " + frmEditor.bfID5.Text)
                    gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN1.Text + Chr(34))
                    gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM1.Text)
                    gen.AppendLine("                BuffLength# = " + frmEditor.bfL1.Text)
                    gen.AppendLine("                BuffID# = " + frmEditor.bfID1.Text)
                    gen.AppendLine("                TotalBuff# = BuffAmount + Attribute(Target, BuffAttribute)")
                    gen.AppendLine("                If TotalBuff < 0")
                    gen.AppendLine("                    Repeat")
                    gen.AppendLine("                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                    Until TotalBuff = 0")
                    gen.AppendLine("                    AddActorEffect(Target, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    AddActorEffect(Target, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                EndIf")
                Else
                    gen.AppendLine("                DeleteActorEffect(Target, BuffName)")
                End If
            End If
        ElseIf frmEditor.bft5.Text = "AOE" Then
            gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN5.Text + Chr(34))
            If frmEditor.bfA5.Checked = True Then
                gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN5.Text + Chr(34))
                gen.AppendLine("                BuffLength# = " + frmEditor.bfL5.Text)
                gen.AppendLine("                BuffID# = " + frmEditor.bfID5.Text)
                gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM5.Text)
                If target = "Allies" Then
                    gen.AppendLine("                AddActorEffect(Player, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                End If
                gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                AOEFaction = HomeFaction(AOETarget)")
                gen.AppendLine("                If Player <> AOETarget")
                gen.AppendLine("                    Repeat")
                gen.AppendLine("                        If AOEDistance <= Range")
                If target = "Allies" Then
                    gen.AppendLine("                            If AOEFaction = CasterFaction")
                    gen.AppendLine("                                TotalBuff# = BuffAmount + Attribute(Player, BuffAttribute)")
                    gen.AppendLine("                                If TotalBuff < 0")
                    gen.AppendLine("                                    Repeat")
                    gen.AppendLine("                                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                                    Until TotalBuff = 0")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                                Else")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                            EndIf")
                Else
                    gen.AppendLine("                            If AOEFaction <> CasterFaction")
                    gen.AppendLine("                                TotalBuff# = BuffAmount + Attribute(Player, BuffAttribute)")
                    gen.AppendLine("                                If TotalBuff < 0")
                    gen.AppendLine("                                    Repeat")
                    gen.AppendLine("                                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                                    Until TotalBuff = 0")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                                Else")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                            EndIf")
                End If
                gen.AppendLine("                        EndIf")
                gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                gen.AppendLine("                        AOETarget = NewTarget")
                gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                        AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                    Until Player = AOETarget")
                gen.AppendLine("                EndIf")
            Else
                gen.AppendLine("                AOETarget = NextActorInZone(Player)") 'savepoint
                gen.AppendLine("                AOEFaction = HomeFaction(AOETarget)")
                gen.AppendLine("                AOEDistance = Actordistance(Player, AOETarget)")
                If target = "Allies" Then
                    gen.AppendLine("                DeleteActorEffect(Player, BuffName)")
                End If
                gen.AppendLine("                If Player <> AOETarget")
                gen.AppendLine("                    Repeat")
                gen.AppendLine("                        AOEFaction = HomeFaction(AOETarget)")
                gen.AppendLine("                        If AOEDistance <= Range")
                gen.AppendLine("                            If AOEFaction = CasterFaction")
                gen.AppendLine("                                    DeleteActorEffect(AOETarget, BuffName)")
                gen.AppendLine("                            EndIf")
                gen.AppendLine("                        EndIf")
                gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                gen.AppendLine("                        AOETarget = NewTarget")
                gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                        AOEDistance = Actordistance(Player, AOETarget)")
                gen.AppendLine("                    Until Player = AOETarget")
                gen.AppendLine("                EndIf")
            End If
        End If
        If frmEditor.bfT5.Text = "Self" Then
            gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN6.Text + Chr(34))
            If frmEditor.bfA6.Checked = True Then
                gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN6.Text + Chr(34))
                gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM6.Text)
                gen.AppendLine("                BuffLength# = " + frmEditor.bfL6.Text)
                gen.AppendLine("                BuffID# = " + frmEditor.bfID6.Text)
                gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN1.Text + Chr(34))
                gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM1.Text)
                gen.AppendLine("                BuffLength# = " + frmEditor.bfL1.Text)
                gen.AppendLine("                BuffID# = " + frmEditor.bfID1.Text)
                gen.AppendLine("                TotalBuff# = BuffAmount + Attribute(Player, BuffAttribute)")
                gen.AppendLine("                If TotalBuff < 0")
                gen.AppendLine("                    Repeat")
                gen.AppendLine("                        TotalBuff = TotalBuff + 1")
                gen.AppendLine("                    Until TotalBuff = 0")
                gen.AppendLine("                    AddActorEffect(Player, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                gen.AppendLine("                Else")
                gen.AppendLine("                    AddActorEffect(Player, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                gen.AppendLine("                EndIf")
            Else
                gen.AppendLine("                DeleteActorEffect(Player, BuffName)")
            End If
        ElseIf frmEditor.bfT5.Text = "Target" Then
            If frmEditor.chkTarget.Checked = True Then
                gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN6.Text + Chr(34))
                If frmEditor.bfA6.Checked = True Then
                    gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN6.Text + Chr(34))
                    gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM6.Text)
                    gen.AppendLine("                BuffLength# = " + frmEditor.bfL6.Text)
                    gen.AppendLine("                BuffID# = " + frmEditor.bfID6.Text)
                    gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN1.Text + Chr(34))
                    gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM1.Text)
                    gen.AppendLine("                BuffLength# = " + frmEditor.bfL1.Text)
                    gen.AppendLine("                BuffID# = " + frmEditor.bfID1.Text)
                    gen.AppendLine("                TotalBuff# = BuffAmount + Attribute(Target, BuffAttribute)")
                    gen.AppendLine("                If TotalBuff < 0")
                    gen.AppendLine("                    Repeat")
                    gen.AppendLine("                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                    Until TotalBuff = 0")
                    gen.AppendLine("                    AddActorEffect(Target, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    AddActorEffect(Target, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                EndIf")
                Else
                    gen.AppendLine("                DeleteActorEffect(Target, BuffName)")
                End If
            End If
        ElseIf frmEditor.bfT5.Text = "AOE" Then
            gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN6.Text + Chr(34))
            If frmEditor.bfA6.Checked = True Then
                gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN6.Text + Chr(34))
                gen.AppendLine("                BuffLength# = " + frmEditor.bfL6.Text)
                gen.AppendLine("                BuffID# = " + frmEditor.bfID6.Text)
                gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM6.Text)
                If target = "Allies" Then
                    gen.AppendLine("                AddActorEffect(Player, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                End If
                gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                AOEFaction = HomeFaction(AOETarget)")
                gen.AppendLine("                If Player <> AOETarget")
                gen.AppendLine("                    Repeat")
                gen.AppendLine("                        If AOEDistance <= Range")
                If target = "Allies" Then
                    gen.AppendLine("                            If AOEFaction = CasterFaction")
                    gen.AppendLine("                                TotalBuff# = BuffAmount + Attribute(Player, BuffAttribute)")
                    gen.AppendLine("                                If TotalBuff < 0")
                    gen.AppendLine("                                    Repeat")
                    gen.AppendLine("                                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                                    Until TotalBuff = 0")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                                Else")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                            EndIf")
                Else
                    gen.AppendLine("                            If AOEFaction <> CasterFaction")
                    gen.AppendLine("                                TotalBuff# = BuffAmount + Attribute(Player, BuffAttribute)")
                    gen.AppendLine("                                If TotalBuff < 0")
                    gen.AppendLine("                                    Repeat")
                    gen.AppendLine("                                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                                    Until TotalBuff = 0")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                                Else")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                            EndIf")
                End If
                gen.AppendLine("                        EndIf")
                gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                gen.AppendLine("                        AOETarget = NewTarget")
                gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                        AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                    Until Player = AOETarget")
                gen.AppendLine("                EndIf")
            Else
                gen.AppendLine("                AOETarget = NextActorInZone(Player)") 'savepoint
                gen.AppendLine("                AOEFaction = HomeFaction(AOETarget)")
                gen.AppendLine("                AOEDistance = Actordistance(Player, AOETarget)")
                If target = "Allies" Then
                    gen.AppendLine("                DeleteActorEffect(Player, BuffName)")
                End If
                gen.AppendLine("                If Player <> AOETarget")
                gen.AppendLine("                    Repeat")
                gen.AppendLine("                        AOEFaction = HomeFaction(AOETarget)")
                gen.AppendLine("                        If AOEDistance <= Range")
                gen.AppendLine("                            If AOEFaction = CasterFaction")
                gen.AppendLine("                                    DeleteActorEffect(AOETarget, BuffName)")
                gen.AppendLine("                            EndIf")
                gen.AppendLine("                        EndIf")
                gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                gen.AppendLine("                        AOETarget = NewTarget")
                gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                        AOEDistance = Actordistance(Player, AOETarget)")
                gen.AppendLine("                    Until Player = AOETarget")
                gen.AppendLine("                EndIf")
            End If
        End If
        If frmEditor.bft7.Text = "Self" Then
            gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN7.Text + Chr(34))
            If frmEditor.bfA7.Checked = True Then
                gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN7.Text + Chr(34))
                gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM7.Text)
                gen.AppendLine("                BuffLength# = " + frmEditor.bfL7.Text)
                gen.AppendLine("                BuffID# = " + frmEditor.bfID7.Text)
                gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN1.Text + Chr(34))
                gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM1.Text)
                gen.AppendLine("                BuffLength# = " + frmEditor.bfL1.Text)
                gen.AppendLine("                BuffID# = " + frmEditor.bfID1.Text)
                gen.AppendLine("                TotalBuff# = BuffAmount + Attribute(Player, BuffAttribute)")
                gen.AppendLine("                If TotalBuff < 0")
                gen.AppendLine("                    Repeat")
                gen.AppendLine("                        TotalBuff = TotalBuff + 1")
                gen.AppendLine("                    Until TotalBuff = 0")
                gen.AppendLine("                    AddActorEffect(Player, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                gen.AppendLine("                Else")
                gen.AppendLine("                    AddActorEffect(Player, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                gen.AppendLine("                EndIf")
            Else
                gen.AppendLine("                DeleteActorEffect(Player, BuffName)")
            End If
        ElseIf frmEditor.bft7.Text = "Target" Then
            If frmEditor.chkTarget.Checked = True Then
                gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN7.Text + Chr(34))
                If frmEditor.bfA7.Checked = True Then
                    gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN7.Text + Chr(34))
                    gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM7.Text)
                    gen.AppendLine("                BuffLength# = " + frmEditor.bfL7.Text)
                    gen.AppendLine("                BuffID# = " + frmEditor.bfID7.Text)
                    gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN1.Text + Chr(34))
                    gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM1.Text)
                    gen.AppendLine("                BuffLength# = " + frmEditor.bfL1.Text)
                    gen.AppendLine("                BuffID# = " + frmEditor.bfID1.Text)
                    gen.AppendLine("                TotalBuff# = BuffAmount + Attribute(Target, BuffAttribute)")
                    gen.AppendLine("                If TotalBuff < 0")
                    gen.AppendLine("                    Repeat")
                    gen.AppendLine("                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                    Until TotalBuff = 0")
                    gen.AppendLine("                    AddActorEffect(Target, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    AddActorEffect(Target, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                EndIf")
                Else
                    gen.AppendLine("                DeleteActorEffect(Target, BuffName)")
                End If
            End If
        ElseIf frmEditor.bft7.Text = "AOE" Then
            gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN7.Text + Chr(34))
            If frmEditor.bfA7.Checked = True Then
                gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN7.Text + Chr(34))
                gen.AppendLine("                BuffLength# = " + frmEditor.bfL7.Text)
                gen.AppendLine("                BuffID# = " + frmEditor.bfID7.Text)
                gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM7.Text)
                If target = "Allies" Then
                    gen.AppendLine("                AddActorEffect(Player, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                End If
                gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                AOEFaction = HomeFaction(AOETarget)")
                gen.AppendLine("                If Player <> AOETarget")
                gen.AppendLine("                    Repeat")
                gen.AppendLine("                        If AOEDistance <= Range")
                If target = "Allies" Then
                    gen.AppendLine("                            If AOEFaction = CasterFaction")
                    gen.AppendLine("                                TotalBuff# = BuffAmount + Attribute(Player, BuffAttribute)")
                    gen.AppendLine("                                If TotalBuff < 0")
                    gen.AppendLine("                                    Repeat")
                    gen.AppendLine("                                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                                    Until TotalBuff = 0")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                                Else")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                            EndIf")
                Else
                    gen.AppendLine("                            If AOEFaction <> CasterFaction")
                    gen.AppendLine("                                TotalBuff# = BuffAmount + Attribute(Player, BuffAttribute)")
                    gen.AppendLine("                                If TotalBuff < 0")
                    gen.AppendLine("                                    Repeat")
                    gen.AppendLine("                                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                                    Until TotalBuff = 0")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                                Else")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                            EndIf")
                End If
                gen.AppendLine("                        EndIf")
                gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                gen.AppendLine("                        AOETarget = NewTarget")
                gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                        AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                    Until Player = AOETarget")
                gen.AppendLine("                EndIf")
            Else
                gen.AppendLine("                AOETarget = NextActorInZone(Player)") 'savepoint
                gen.AppendLine("                AOEFaction = HomeFaction(AOETarget)")
                gen.AppendLine("                AOEDistance = Actordistance(Player, AOETarget)")
                If target = "Allies" Then
                    gen.AppendLine("                DeleteActorEffect(Player, BuffName)")
                End If
                gen.AppendLine("                If Player <> AOETarget")
                gen.AppendLine("                    Repeat")
                gen.AppendLine("                        AOEFaction = HomeFaction(AOETarget)")
                gen.AppendLine("                        If AOEDistance <= Range")
                gen.AppendLine("                            If AOEFaction = CasterFaction")
                gen.AppendLine("                                    DeleteActorEffect(AOETarget, BuffName)")
                gen.AppendLine("                            EndIf")
                gen.AppendLine("                        EndIf")
                gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                gen.AppendLine("                        AOETarget = NewTarget")
                gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                        AOEDistance = Actordistance(Player, AOETarget)")
                gen.AppendLine("                    Until Player = AOETarget")
                gen.AppendLine("                EndIf")
            End If
        End If
        If frmEditor.bft8.Text = "Self" Then
            gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN8.Text + Chr(34))
            If frmEditor.bfA8.Checked = True Then
                gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN8.Text + Chr(34))
                gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM8.Text)
                gen.AppendLine("                BuffLength# = " + frmEditor.bfL8.Text)
                gen.AppendLine("                BuffID# = " + frmEditor.bfID8.Text)
                gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN1.Text + Chr(34))
                gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM1.Text)
                gen.AppendLine("                BuffLength# = " + frmEditor.bfL1.Text)
                gen.AppendLine("                BuffID# = " + frmEditor.bfID1.Text)
                gen.AppendLine("                TotalBuff# = BuffAmount + Attribute(Player, BuffAttribute)")
                gen.AppendLine("                If TotalBuff < 0")
                gen.AppendLine("                    Repeat")
                gen.AppendLine("                        TotalBuff = TotalBuff + 1")
                gen.AppendLine("                    Until TotalBuff = 0")
                gen.AppendLine("                    AddActorEffect(Player, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                gen.AppendLine("                Else")
                gen.AppendLine("                    AddActorEffect(Player, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                gen.AppendLine("                EndIf")
            Else
                gen.AppendLine("                DeleteActorEffect(Player, BuffName)")
            End If
        ElseIf frmEditor.bft8.Text = "Target" Then
            If frmEditor.chkTarget.Checked = True Then
                gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN8.Text + Chr(34))
                If frmEditor.bfA8.Checked = True Then
                    gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN8.Text + Chr(34))
                    gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM8.Text)
                    gen.AppendLine("                BuffLength# = " + frmEditor.bfL8.Text)
                    gen.AppendLine("                BuffID# = " + frmEditor.bfID8.Text)
                    gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN1.Text + Chr(34))
                    gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM1.Text)
                    gen.AppendLine("                BuffLength# = " + frmEditor.bfL1.Text)
                    gen.AppendLine("                BuffID# = " + frmEditor.bfID1.Text)
                    gen.AppendLine("                TotalBuff# = BuffAmount + Attribute(Target, BuffAttribute)")
                    gen.AppendLine("                If TotalBuff < 0")
                    gen.AppendLine("                    Repeat")
                    gen.AppendLine("                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                    Until TotalBuff = 0")
                    gen.AppendLine("                    AddActorEffect(Target, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    AddActorEffect(Target, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                EndIf")
                Else
                    gen.AppendLine("                DeleteActorEffect(Target, BuffName)")
                End If
            End If
        ElseIf frmEditor.bft8.Text = "AOE" Then
            gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN8.Text + Chr(34))
            If frmEditor.bfA8.Checked = True Then
                gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN8.Text + Chr(34))
                gen.AppendLine("                BuffLength# = " + frmEditor.bfL8.Text)
                gen.AppendLine("                BuffID# = " + frmEditor.bfID8.Text)
                gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM8.Text)
                If target = "Allies" Then
                    gen.AppendLine("                AddActorEffect(Player, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                End If
                gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                AOEFaction = HomeFaction(AOETarget)")
                gen.AppendLine("                If Player <> AOETarget")
                gen.AppendLine("                    Repeat")
                gen.AppendLine("                        If AOEDistance <= Range")
                If target = "Allies" Then
                    gen.AppendLine("                            If AOEFaction = CasterFaction")
                    gen.AppendLine("                                TotalBuff# = BuffAmount + Attribute(Player, BuffAttribute)")
                    gen.AppendLine("                                If TotalBuff < 0")
                    gen.AppendLine("                                    Repeat")
                    gen.AppendLine("                                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                                    Until TotalBuff = 0")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                                Else")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                            EndIf")
                Else
                    gen.AppendLine("                            If AOEFaction <> CasterFaction")
                    gen.AppendLine("                                TotalBuff# = BuffAmount + Attribute(Player, BuffAttribute)")
                    gen.AppendLine("                                If TotalBuff < 0")
                    gen.AppendLine("                                    Repeat")
                    gen.AppendLine("                                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                                    Until TotalBuff = 0")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                                Else")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                            EndIf")
                End If
                gen.AppendLine("                        EndIf")
                gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                gen.AppendLine("                        AOETarget = NewTarget")
                gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                        AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                    Until Player = AOETarget")
                gen.AppendLine("                EndIf")
            Else
                gen.AppendLine("                AOETarget = NextActorInZone(Player)") 'savepoint
                gen.AppendLine("                AOEFaction = HomeFaction(AOETarget)")
                gen.AppendLine("                AOEDistance = Actordistance(Player, AOETarget)")
                If target = "Allies" Then
                    gen.AppendLine("                DeleteActorEffect(Player, BuffName)")
                End If
                gen.AppendLine("                If Player <> AOETarget")
                gen.AppendLine("                    Repeat")
                gen.AppendLine("                        AOEFaction = HomeFaction(AOETarget)")
                gen.AppendLine("                        If AOEDistance <= Range")
                gen.AppendLine("                            If AOEFaction = CasterFaction")
                gen.AppendLine("                                    DeleteActorEffect(AOETarget, BuffName)")
                gen.AppendLine("                            EndIf")
                gen.AppendLine("                        EndIf")
                gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                gen.AppendLine("                        AOETarget = NewTarget")
                gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                        AOEDistance = Actordistance(Player, AOETarget)")
                gen.AppendLine("                    Until Player = AOETarget")
                gen.AppendLine("                EndIf")
            End If
        End If
        If frmEditor.bft9.Text = "Self" Then
            gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN9.Text + Chr(34))
            If frmEditor.bfA9.Checked = True Then
                gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN9.Text + Chr(34))
                gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM9.Text)
                gen.AppendLine("                BuffLength# = " + frmEditor.bfL9.Text)
                gen.AppendLine("                BuffID# = " + frmEditor.bfID9.Text)
                gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN1.Text + Chr(34))
                gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM1.Text)
                gen.AppendLine("                BuffLength# = " + frmEditor.bfL1.Text)
                gen.AppendLine("                BuffID# = " + frmEditor.bfID1.Text)
                gen.AppendLine("                TotalBuff# = BuffAmount + Attribute(Player, BuffAttribute)")
                gen.AppendLine("                If TotalBuff < 0")
                gen.AppendLine("                    Repeat")
                gen.AppendLine("                        TotalBuff = TotalBuff + 1")
                gen.AppendLine("                    Until TotalBuff = 0")
                gen.AppendLine("                    AddActorEffect(Player, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                gen.AppendLine("                Else")
                gen.AppendLine("                    AddActorEffect(Player, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                gen.AppendLine("                EndIf")
            Else
                gen.AppendLine("                DeleteActorEffect(Player, BuffName)")
            End If
        ElseIf frmEditor.bft9.Text = "Target" Then
            If frmEditor.chkTarget.Checked = True Then
                gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN9.Text + Chr(34))
                If frmEditor.bfA9.Checked = True Then
                    gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN9.Text + Chr(34))
                    gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM9.Text)
                    gen.AppendLine("                BuffLength# = " + frmEditor.bfL9.Text)
                    gen.AppendLine("                BuffID# = " + frmEditor.bfID9.Text)
                    gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN1.Text + Chr(34))
                    gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM1.Text)
                    gen.AppendLine("                BuffLength# = " + frmEditor.bfL1.Text)
                    gen.AppendLine("                BuffID# = " + frmEditor.bfID1.Text)
                    gen.AppendLine("                TotalBuff# = BuffAmount + Attribute(Target, BuffAttribute)")
                    gen.AppendLine("                If TotalBuff < 0")
                    gen.AppendLine("                    Repeat")
                    gen.AppendLine("                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                    Until TotalBuff = 0")
                    gen.AppendLine("                    AddActorEffect(Target, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    AddActorEffect(Target, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                EndIf")
                Else
                    gen.AppendLine("                DeleteActorEffect(Target, BuffName)")
                End If
            End If
        ElseIf frmEditor.bft9.Text = "AOE" Then
            gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN9.Text + Chr(34))
            If frmEditor.bfA9.Checked = True Then
                gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN9.Text + Chr(34))
                gen.AppendLine("                BuffLength# = " + frmEditor.bfL9.Text)
                gen.AppendLine("                BuffID# = " + frmEditor.bfID9.Text)
                gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM9.Text)
                If target = "Allies" Then
                    gen.AppendLine("                AddActorEffect(Player, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                End If
                gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                AOEFaction = HomeFaction(AOETarget)")
                gen.AppendLine("                If Player <> AOETarget")
                gen.AppendLine("                    Repeat")
                gen.AppendLine("                        If AOEDistance <= Range")
                If target = "Allies" Then
                    gen.AppendLine("                            If AOEFaction = CasterFaction")
                    gen.AppendLine("                                TotalBuff# = BuffAmount + Attribute(Player, BuffAttribute)")
                    gen.AppendLine("                                If TotalBuff < 0")
                    gen.AppendLine("                                    Repeat")
                    gen.AppendLine("                                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                                    Until TotalBuff = 0")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                                Else")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                            EndIf")
                Else
                    gen.AppendLine("                            If AOEFaction <> CasterFaction")
                    gen.AppendLine("                                TotalBuff# = BuffAmount + Attribute(Player, BuffAttribute)")
                    gen.AppendLine("                                If TotalBuff < 0")
                    gen.AppendLine("                                    Repeat")
                    gen.AppendLine("                                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                                    Until TotalBuff = 0")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                                Else")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                            EndIf")
                End If
                gen.AppendLine("                        EndIf")
                gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                gen.AppendLine("                        AOETarget = NewTarget")
                gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                        AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                    Until Player = AOETarget")
                gen.AppendLine("                EndIf")
            Else
                gen.AppendLine("                AOETarget = NextActorInZone(Player)") 'savepoint
                gen.AppendLine("                AOEFaction = HomeFaction(AOETarget)")
                gen.AppendLine("                AOEDistance = Actordistance(Player, AOETarget)")
                If target = "Allies" Then
                    gen.AppendLine("                DeleteActorEffect(Player, BuffName)")
                End If
                gen.AppendLine("                If Player <> AOETarget")
                gen.AppendLine("                    Repeat")
                gen.AppendLine("                        AOEFaction = HomeFaction(AOETarget)")
                gen.AppendLine("                        If AOEDistance <= Range")
                gen.AppendLine("                            If AOEFaction = CasterFaction")
                gen.AppendLine("                                    DeleteActorEffect(AOETarget, BuffName)")
                gen.AppendLine("                            EndIf")
                gen.AppendLine("                        EndIf")
                gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                gen.AppendLine("                        AOETarget = NewTarget")
                gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                        AOEDistance = Actordistance(Player, AOETarget)")
                gen.AppendLine("                    Until Player = AOETarget")
                gen.AppendLine("                EndIf")
            End If
        End If
        If frmEditor.bft10.Text = "Self" Then
            gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN10.Text + Chr(34))
            If frmEditor.bfA10.Checked = True Then
                gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN10.Text + Chr(34))
                gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM10.Text)
                gen.AppendLine("                BuffLength# = " + frmEditor.bfL10.Text)
                gen.AppendLine("                BuffID# = " + frmEditor.bfID10.Text)
                gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN1.Text + Chr(34))
                gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM1.Text)
                gen.AppendLine("                BuffLength# = " + frmEditor.bfL1.Text)
                gen.AppendLine("                BuffID# = " + frmEditor.bfID1.Text)
                gen.AppendLine("                TotalBuff# = BuffAmount + Attribute(Player, BuffAttribute)")
                gen.AppendLine("                If TotalBuff < 0")
                gen.AppendLine("                    Repeat")
                gen.AppendLine("                        TotalBuff = TotalBuff + 1")
                gen.AppendLine("                    Until TotalBuff = 0")
                gen.AppendLine("                    AddActorEffect(Player, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                gen.AppendLine("                Else")
                gen.AppendLine("                    AddActorEffect(Player, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                gen.AppendLine("                EndIf")
            Else
                gen.AppendLine("                DeleteActorEffect(Player, BuffName)")
            End If
        ElseIf frmEditor.bft10.Text = "Target" Then
            If frmEditor.chkTarget.Checked = True Then
                gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN10.Text + Chr(34))
                If frmEditor.bfA10.Checked = True Then
                    gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN10.Text + Chr(34))
                    gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM10.Text)
                    gen.AppendLine("                BuffLength# = " + frmEditor.bfL10.Text)
                    gen.AppendLine("                BuffID# = " + frmEditor.bfID10.Text)
                    gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN1.Text + Chr(34))
                    gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM1.Text)
                    gen.AppendLine("                BuffLength# = " + frmEditor.bfL1.Text)
                    gen.AppendLine("                BuffID# = " + frmEditor.bfID1.Text)
                    gen.AppendLine("                TotalBuff# = BuffAmount + Attribute(Target, BuffAttribute)")
                    gen.AppendLine("                If TotalBuff < 0")
                    gen.AppendLine("                    Repeat")
                    gen.AppendLine("                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                    Until TotalBuff = 0")
                    gen.AppendLine("                    AddActorEffect(Target, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    AddActorEffect(Target, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                EndIf")
                Else
                    gen.AppendLine("                DeleteActorEffect(Target, BuffName)")
                End If
            End If
        ElseIf frmEditor.bft10.Text = "AOE" Then
            gen.AppendLine("                BuffName$ = " + Chr(34) + frmEditor.bfN10.Text + Chr(34))
            If frmEditor.bfA10.Checked = True Then
                gen.AppendLine("                BuffAttribute$ = " + Chr(34) + frmEditor.bfAN10.Text + Chr(34))
                gen.AppendLine("                BuffLength# = " + frmEditor.bfL10.Text)
                gen.AppendLine("                BuffID# = " + frmEditor.bfID10.Text)
                gen.AppendLine("                BuffAmount# = " + frmEditor.bfAM10.Text)
                If target = "Allies" Then
                    gen.AppendLine("                AddActorEffect(Player, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                End If
                gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                AOEFaction = HomeFaction(AOETarget)")
                gen.AppendLine("                If Player <> AOETarget")
                gen.AppendLine("                    Repeat")
                gen.AppendLine("                        If AOEDistance <= Range")
                If target = "Allies" Then
                    gen.AppendLine("                            If AOEFaction = CasterFaction")
                    gen.AppendLine("                                TotalBuff# = BuffAmount + Attribute(Player, BuffAttribute)")
                    gen.AppendLine("                                If TotalBuff < 0")
                    gen.AppendLine("                                    Repeat")
                    gen.AppendLine("                                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                                    Until TotalBuff = 0")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                                Else")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                            EndIf")
                Else
                    gen.AppendLine("                            If AOEFaction <> CasterFaction")
                    gen.AppendLine("                                TotalBuff# = BuffAmount + Attribute(Player, BuffAttribute)")
                    gen.AppendLine("                                If TotalBuff < 0")
                    gen.AppendLine("                                    Repeat")
                    gen.AppendLine("                                        TotalBuff = TotalBuff + 1")
                    gen.AppendLine("                                    Until TotalBuff = 0")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, TotalBuff, BuffLength, BuffID)")
                    gen.AppendLine("                                Else")
                    gen.AppendLine("                                    AddActorEffect(AOETarget, BuffName, BuffAttribute, BuffAmount, BuffLength, BuffID)")
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                            EndIf")
                End If
                gen.AppendLine("                        EndIf")
                gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                gen.AppendLine("                        AOETarget = NewTarget")
                gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                        AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                    Until Player = AOETarget")
                gen.AppendLine("                EndIf")
            Else
                gen.AppendLine("                AOETarget = NextActorInZone(Player)") 'savepoint
                gen.AppendLine("                AOEFaction = HomeFaction(AOETarget)")
                gen.AppendLine("                AOEDistance = Actordistance(Player, AOETarget)")
                If target = "Allies" Then
                    gen.AppendLine("                DeleteActorEffect(Player, BuffName)")
                End If
                gen.AppendLine("                If Player <> AOETarget")
                gen.AppendLine("                    Repeat")
                gen.AppendLine("                        AOEFaction = HomeFaction(AOETarget)")
                gen.AppendLine("                        If AOEDistance <= Range")
                gen.AppendLine("                            If AOEFaction = CasterFaction")
                gen.AppendLine("                                    DeleteActorEffect(AOETarget, BuffName)")
                gen.AppendLine("                            EndIf")
                gen.AppendLine("                        EndIf")
                gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                gen.AppendLine("                        AOETarget = NewTarget")
                gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                        AOEDistance = Actordistance(Player, AOETarget)")
                gen.AppendLine("                    Until Player = AOETarget")
                gen.AppendLine("                EndIf")
            End If
        End If
        'SPAWN ACTOR
        If frmEditor.saID.Text = "" Then
        Else
            gen.AppendLine("                ID = " + frmEditor.saID.Text)
            If frmEditor.saSOP.Checked = True Then
                gen.AppendLine("                Zone = ActorZone(Player)")
                gen.AppendLine("                X# = ActorX(Player)")
                gen.AppendLine("                Y# = ActorY(Player)")
                gen.AppendLine("                Z# = ActorZ(Player)")
            Else
                gen.AppendLine("                Zone = " + frmEditor.saZone.Text)
                gen.AppendLine("                X = " + frmEditor.saX.Text)
                gen.AppendLine("                Y = " + frmEditor.saY.Text)
                gen.AppendLine("                Z = " + frmEditor.saZ.Text)
            End If
            If frmEditor.saRightClick.Text = "" Then
            Else
                gen.AppendLine("                RightClick = " + frmEditor.saRightClick.Text)
            End If
            If frmEditor.saDeath.Text = "" Then
            Else
                gen.AppendLine("                Death = " + frmEditor.saDeath.Text)
            End If
            If frmEditor.saNumber.Text = "" Then
                gen.AppendLine("                Number = 1")
            Else
                gen.AppendLine("                Number = " + frmEditor.saNumber.Text)
            End If
            gen.AppendLine("                Spawning = Number")
            gen.AppendLine("                Repeat")
            gen.AppendLine("                    Spawning = Spawning - 1")
            If frmEditor.saRightClick.Text = "" Then
                gen.AppendLine("                    SpawnAct = Spawn(ID, Zone, X, Y, Z)")
            Else
                If frmEditor.saDeath.Text = "" Then
                    gen.AppendLine("                    SpawnAct = Spawn(ID, Zone, X, Y, Z, RightClick)")
                Else
                    gen.AppendLine("                    SpawnAct = Spawn(ID, Zone, X, Y, Z, RightClick, Death)")
                End If
            End If

            If frmEditor.saName.Text = "" Then
            Else
                gen.AppendLine("                    SetName(SpawnAct, " + Chr(34) + frmEditor.saName.Text + Chr(34) + ")")
            End If
            If frmEditor.saTag.Text = "" Then
            Else
                gen.AppendLine("                    SetTag(SpawnAct, " + Chr(34) + frmEditor.saTag.Text + Chr(34) + ")")
            End If
            If frmEditor.saLevel.Text = "" Then
            Else
                gen.AppendLine("                    SetActorLevel(SpawnAct, " + frmEditor.saLevel.Text + ")")
            End If
            If frmEditor.saCBP.Checked = True Then
                gen.AppendLine("                    SetLeader(SpawnAct, Player)")
            Else
            End If
            If frmEditor.saIN1.Text = "" Then
            Else
                gen.AppendLine("                    ItemNameSpawn$ = " + Chr(34) + frmEditor.saIN1.Text + Chr(34))
                gen.AppendLine("                    ItemAmount# = " + frmEditor.saIA1.Text)
                gen.AppendLine("                    GiveItem(SpawnAct, ItemNameSpawn, ItemAmount)")
            End If
            If frmEditor.saIN2.Text = "" Then
            Else
                gen.AppendLine("                    ItemNameSpawn$ = " + Chr(34) + frmEditor.saIN2.Text + Chr(34))
                gen.AppendLine("                    ItemAmount# = " + frmEditor.saIA2.Text)
                gen.AppendLine("                    GiveItem(SpawnAct, ItemNameSpawn, ItemAmount)")
            End If
            If frmEditor.saIN3.Text = "" Then
            Else
                gen.AppendLine("                    ItemNameSpawn$ = " + Chr(34) + frmEditor.saIN3.Text + Chr(34))
                gen.AppendLine("                    ItemAmount# = " + frmEditor.saIA3.Text)
                gen.AppendLine("                    GiveItem(SpawnAct, ItemNameSpawn, ItemAmount)")
            End If
            If frmEditor.saIN4.Text = "" Then
            Else
                gen.AppendLine("                    ItemNameSpawn$ = " + Chr(34) + frmEditor.saIN4.Text + Chr(34))
                gen.AppendLine("                    ItemAmount# = " + frmEditor.saIA4.Text)
                gen.AppendLine("                    GiveItem(SpawnAct, ItemNameSpawn, ItemAmount)")
            End If
            If frmEditor.saIN5.Text = "" Then
            Else
                gen.AppendLine("                    ItemNameSpawn$ = " + Chr(34) + frmEditor.saIN5.Text + Chr(34))
                gen.AppendLine("                    ItemAmount# = " + frmEditor.saIA5.Text)
                gen.AppendLine("                    GiveItem(SpawnAct, ItemNameSpawn, ItemAmount)")
            End If
            If frmEditor.saIN6.Text = "" Then
            Else
                gen.AppendLine("                    ItemNameSpawn$ = " + Chr(34) + frmEditor.saIN6.Text + Chr(34))
                gen.AppendLine("                    ItemAmount# = " + frmEditor.saIA6.Text)
                gen.AppendLine("                    GiveItem(SpawnAct, ItemNameSpawn, ItemAmount)")
            End If
            If frmEditor.saIN7.Text = "" Then
            Else
                gen.AppendLine("                    ItemNameSpawn$ = " + Chr(34) + frmEditor.saIN7.Text + Chr(34))
                gen.AppendLine("                    ItemAmount# = " + frmEditor.saIA7.Text)
                gen.AppendLine("                    GiveItem(SpawnAct, ItemNameSpawn, ItemAmount)")
            End If
            If frmEditor.saIN8.Text = "" Then
            Else
                gen.AppendLine("                    ItemNameSpawn$ = " + Chr(34) + frmEditor.saIN8.Text + Chr(34))
                gen.AppendLine("                    ItemAmount# = " + frmEditor.saIA8.Text)
                gen.AppendLine("                    GiveItem(SpawnAct, ItemNameSpawn, ItemAmount)")
            End If
            gen.AppendLine("                Until Spawning = 0")
        End If
        If frmEditor.itmL1.Text = "Select" Then
        Else
            gen.AppendLine("                Item$ = " + Chr(34) + frmEditor.itmN1.Text + Chr(34))
            gen.AppendLine("                ItemAmt# = " + frmEditor.itmA1.Text)
            If frmEditor.itmL1.Text = "Spawn on Ground" Then
                gen.AppendLine("                Zone = ActorZone(Player)")
                gen.AppendLine("                X# = ActorX(Player)")
                gen.AppendLine("                Y# = ActorY(Player)")
                gen.AppendLine("                Z# = ActorZ(Player)")
                gen.AppendLine("                SpawnItem(Item, ItemAmt, Zone, X, Y, Z)")
            ElseIf frmEditor.itmL1.Text = "Caster" Then
                gen.AppendLine("                GiveItem(Player, Item, ItemAmt)")
            ElseIf frmEditor.itmL1.Text = "Target" Then
                If frmEditor.chkTarget.Checked = True Then
                    gen.AppendLine("                GiveItem(Target, Item, ItemAmt)")
                End If
            ElseIf frmEditor.itmL1.Text = "AOE" Then 'LASTPOINTSAVE
                gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                If Player <> AOETarget")
                gen.AppendLine("                            Repeat")
                gen.AppendLine("                                If AOEDistance <= Range")
                If target = "Allies" Then
                    gen.AppendLine("                                    If CasterFaction = AOEFaction")
                    gen.AppendLine("                                        GiveItem(AOETarget, Item, ItemAmt)")
                    gen.AppendLine("                                    EndIf")
                Else
                    gen.AppendLine("                                    If CasterFaction <> AOEFaction")
                    gen.AppendLine("                                        GiveItem(AOETarget, Item, ItemAmt)")
                    gen.AppendLine("                                    EndIf")
                End If
                gen.AppendLine("                                EndIf")
                gen.AppendLine("                                NewTarget = NextActorInZone(AOETarget)")
                gen.AppendLine("                                AOETarget = NewTarget")
                gen.AppendLine("                                AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                                AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                            Until Player = AOETarget")
                gen.AppendLine("                EndIf")
            End If
        End If
        If frmEditor.itmL2.Text = "Select" Then
        Else
            gen.AppendLine("                Item$ = " + Chr(34) + frmEditor.itmN2.Text + Chr(34))
            gen.AppendLine("                ItemAmt# = " + frmEditor.itmA2.Text)
            If frmEditor.itmL2.Text = "Spawn on Ground" Then
                gen.AppendLine("                Zone = ActorZone(Player)")
                gen.AppendLine("                X# = ActorX(Player)")
                gen.AppendLine("                Y# = ActorY(Player)")
                gen.AppendLine("                Z# = ActorZ(Player)")
                gen.AppendLine("                SpawnItem(Item, ItemAmt, Zone, X, Y, Z)")
            ElseIf frmEditor.itmL2.Text = "Caster" Then
                gen.AppendLine("                GiveItem(Player, Item, ItemAmt)")
            ElseIf frmEditor.itmL2.Text = "Target" Then
                If frmEditor.chkTarget.Checked = True Then
                    gen.AppendLine("                GiveItem(Target, Item, ItemAmt)")
                End If
            ElseIf frmEditor.itmL2.Text = "AOE" Then
                gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                If Player <> AOETarget")
                gen.AppendLine("                            Repeat")
                gen.AppendLine("                                If AOEDistance <= Range")
                If target = "Allies" Then
                    gen.AppendLine("                                    If CasterFaction = AOEFaction")
                    gen.AppendLine("                                        GiveItem(AOETarget, Item, ItemAmt)")
                    gen.AppendLine("                                    EndIf")
                Else
                    gen.AppendLine("                                    If CasterFaction <> AOEFaction")
                    gen.AppendLine("                                        GiveItem(AOETarget, Item, ItemAmt)")
                    gen.AppendLine("                                    EndIf")
                End If
                gen.AppendLine("                                EndIf")
                gen.AppendLine("                                NewTarget = NextActorInZone(AOETarget)")
                gen.AppendLine("                                AOETarget = NewTarget")
                gen.AppendLine("                                AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                                AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                            Until Player = AOETarget")
                gen.AppendLine("                EndIf")
            End If
        End If
        If frmEditor.itmL3.Text = "Select" Then
        Else
            gen.AppendLine("                Item$ = " + Chr(34) + frmEditor.itmN3.Text + Chr(34))
            gen.AppendLine("                ItemAmt# = " + frmEditor.itmA3.Text)
            If frmEditor.itmL3.Text = "Spawn on Ground" Then
                gen.AppendLine("                Zone = ActorZone(Player)")
                gen.AppendLine("                X# = ActorX(Player)")
                gen.AppendLine("                Y# = ActorY(Player)")
                gen.AppendLine("                Z# = ActorZ(Player)")
                gen.AppendLine("                SpawnItem(Item, ItemAmt, Zone, X, Y, Z)")
            ElseIf frmEditor.itmL3.Text = "Caster" Then
                gen.AppendLine("                GiveItem(Player, Item, ItemAmt)")
            ElseIf frmEditor.itmL3.Text = "Target" Then
                If frmEditor.chkTarget.Checked = True Then
                    gen.AppendLine("                GiveItem(Target, Item, ItemAmt)")
                End If
            ElseIf frmEditor.itmL3.Text = "AOE" Then
                gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                If Player <> AOETarget")
                gen.AppendLine("                            Repeat")
                gen.AppendLine("                                If AOEDistance <= Range")
                If target = "Allies" Then
                    gen.AppendLine("                                    If CasterFaction = AOEFaction")
                    gen.AppendLine("                                        GiveItem(AOETarget, Item, ItemAmt)")
                    gen.AppendLine("                                    EndIf")
                Else
                    gen.AppendLine("                                    If CasterFaction <> AOEFaction")
                    gen.AppendLine("                                        GiveItem(AOETarget, Item, ItemAmt)")
                    gen.AppendLine("                                    EndIf")
                End If
                gen.AppendLine("                                EndIf")
                gen.AppendLine("                                NewTarget = NextActorInZone(AOETarget)")
                gen.AppendLine("                                AOETarget = NewTarget")
                gen.AppendLine("                                AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                                AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                            Until Player = AOETarget")
                gen.AppendLine("                EndIf")
            End If
        End If
        If frmEditor.itmL4.Text = "Select" Then
        Else
            gen.AppendLine("                Item$ = " + Chr(34) + frmEditor.itmN4.Text + Chr(34))
            gen.AppendLine("                ItemAmt# = " + frmEditor.itmA4.Text)
            If frmEditor.itmL4.Text = "Spawn on Ground" Then
                gen.AppendLine("                Zone = ActorZone(Player)")
                gen.AppendLine("                X# = ActorX(Player)")
                gen.AppendLine("                Y# = ActorY(Player)")
                gen.AppendLine("                Z# = ActorZ(Player)")
                gen.AppendLine("                SpawnItem(Item, ItemAmt, Zone, X, Y, Z)")
            ElseIf frmEditor.itmL4.Text = "Caster" Then
                gen.AppendLine("                GiveItem(Player, Item, ItemAmt)")
            ElseIf frmEditor.itmL4.Text = "Target" Then
                If frmEditor.chkTarget.Checked = True Then
                    gen.AppendLine("                GiveItem(Target, Item, ItemAmt)")
                End If
            ElseIf frmEditor.itmL4.Text = "AOE" Then
                gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                If Player <> AOETarget")
                gen.AppendLine("                            Repeat")
                gen.AppendLine("                                If AOEDistance <= Range")
                If target = "Allies" Then
                    gen.AppendLine("                                    If CasterFaction = AOEFaction")
                    gen.AppendLine("                                        GiveItem(AOETarget, Item, ItemAmt)")
                    gen.AppendLine("                                    EndIf")
                Else
                    gen.AppendLine("                                    If CasterFaction <> AOEFaction")
                    gen.AppendLine("                                        GiveItem(AOETarget, Item, ItemAmt)")
                    gen.AppendLine("                                    EndIf")
                End If
                gen.AppendLine("                                EndIf")
                gen.AppendLine("                                NewTarget = NextActorInZone(AOETarget)")
                gen.AppendLine("                                AOETarget = NewTarget")
                gen.AppendLine("                                AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                                AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                            Until Player = AOETarget")
                gen.AppendLine("                EndIf")
            End If
        End If
        If frmEditor.itmL5.Text = "Select" Then
        Else
            gen.AppendLine("                Item$ = " + Chr(34) + frmEditor.itmN5.Text + Chr(34))
            gen.AppendLine("                ItemAmt# = " + frmEditor.itmA5.Text)
            If frmEditor.itmL5.Text = "Spawn on Ground" Then
                gen.AppendLine("                Zone = ActorZone(Player)")
                gen.AppendLine("                X# = ActorX(Player)")
                gen.AppendLine("                Y# = ActorY(Player)")
                gen.AppendLine("                Z# = ActorZ(Player)")
                gen.AppendLine("                SpawnItem(Item, ItemAmt, Zone, X, Y, Z)")
            ElseIf frmEditor.itmL5.Text = "Caster" Then
                gen.AppendLine("                GiveItem(Player, Item, ItemAmt)")
            ElseIf frmEditor.itmL5.Text = "Target" Then
                If frmEditor.chkTarget.Checked = True Then
                    gen.AppendLine("                GiveItem(Target, Item, ItemAmt)")
                End If
            ElseIf frmEditor.itmL5.Text = "AOE" Then
                gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                If Player <> AOETarget")
                gen.AppendLine("                            Repeat")
                gen.AppendLine("                                If AOEDistance <= Range")
                If target = "Allies" Then
                    gen.AppendLine("                                    If CasterFaction = AOEFaction")
                    gen.AppendLine("                                        GiveItem(AOETarget, Item, ItemAmt)")
                    gen.AppendLine("                                    EndIf")
                Else
                    gen.AppendLine("                                    If CasterFaction <> AOEFaction")
                    gen.AppendLine("                                        GiveItem(AOETarget, Item, ItemAmt)")
                    gen.AppendLine("                                    EndIf")
                End If
                gen.AppendLine("                                EndIf")
                gen.AppendLine("                                NewTarget = NextActorInZone(AOETarget)")
                gen.AppendLine("                                AOETarget = NewTarget")
                gen.AppendLine("                                AOEFaction$ = HomeFaction(AOETarget)")
                gen.AppendLine("                                AOEDistance = ActorDistance(Player, AOETarget)")
                gen.AppendLine("                            Until Player = AOETarget")
                gen.AppendLine("                EndIf")
            End If
        End If
        If frmEditor.atrN1.Text = "" Then 'GIVEOUTATTRI
        Else
            gen.AppendLine("                AttributeName$ = " + Chr(34) + frmEditor.atrN1.Text + Chr(34))
            gen.AppendLine("                AttributeAmt# = " + frmEditor.atrAm1.Text)
            If frmEditor.atrT1.Text = "Self" Then
                If frmEditor.atrA1.Text = "+/-" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute + AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atrA1.Text = "x" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute * AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atrA1.Text = "/" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute / AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                End If
            ElseIf frmEditor.atrT1.Text = "Target" Then
                If frmEditor.chkTarget.Checked = True Then
                    If frmEditor.atrA1.Text = "+/-" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute + AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    ElseIf frmEditor.atrA1.Text = "x" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute * AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    ElseIf frmEditor.atrA1.Text = "/" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute / AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                End If
            ElseIf frmEditor.atrT1.Text = "AOE" Then 'atriman
                If frmEditor.atrA1.Text = "+/-" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer + AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                    Repeat")
                    gen.AppendLine("                        If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                            If AOEFaction = CasterFaction")
                        gen.AppendLine("                                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                Else")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                EndIf")
                        gen.AppendLine("                            EndIf")
                    Else
                        gen.AppendLine("                            If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                Else")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                EndIf")
                        gen.AppendLine("                            EndIf")
                    End If
                    gen.AppendLine("                        EndIf")
                    gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                        AOETarget = NewTarget")
                    gen.AppendLine("                        TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                        TotalAmt = TotalAttribute + AttributeAmt")
                    gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                        AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                    Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atrA1.Text = "x" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer * AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                            Repeat")
                    gen.AppendLine("                                If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                                If AOEFaction = CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    Else
                        gen.AppendLine("                                If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    End If
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                                NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                                AOETarget = NewTarget")
                    gen.AppendLine("                                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                                TotalAmt = TotalAttribute * AttributeAmt")
                    gen.AppendLine("                                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                            Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atrA1.Text = "/" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer / AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                            Repeat")
                    gen.AppendLine("                                If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                                If AOEFaction = CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    Else
                        gen.AppendLine("                                If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    End If
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                                NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                                AOETarget = NewTarget")
                    gen.AppendLine("                                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                                TotalAmt = TotalAttribute / AttributeAmt")
                    gen.AppendLine("                                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                            Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                End If
            End If
        End If

        If frmEditor.atrN1.Text = "" Then
        Else
            gen.AppendLine("                AttributeName$ = " + Chr(34) + frmEditor.atrN1.Text + Chr(34))
            gen.AppendLine("                AttributeAmt# = " + frmEditor.atrAm2.Text)
            If frmEditor.atrt2.Text = "Self" Then
                If frmEditor.atra2.Text = "+/-" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute + AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra2.Text = "x" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute * AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra2.Text = "/" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute / AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                End If
            ElseIf frmEditor.atrt2.Text = "Target" Then
                If frmEditor.chkTarget.Checked = True Then
                    If frmEditor.atra2.Text = "+/-" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute + AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    ElseIf frmEditor.atra2.Text = "x" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute * AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    ElseIf frmEditor.atra2.Text = "/" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute / AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                End If
            ElseIf frmEditor.atrt2.Text = "AOE" Then 'atriman
                If frmEditor.atra2.Text = "+/-" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer + AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                    Repeat")
                    gen.AppendLine("                        If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                            If AOEFaction = CasterFaction")
                        gen.AppendLine("                                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                Else")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                EndIf")
                        gen.AppendLine("                            EndIf")
                    Else
                        gen.AppendLine("                            If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                Else")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                EndIf")
                        gen.AppendLine("                            EndIf")
                    End If
                    gen.AppendLine("                        EndIf")
                    gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                        AOETarget = NewTarget")
                    gen.AppendLine("                        TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                        TotalAmt = TotalAttribute + AttributeAmt")
                    gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                        AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                    Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra2.Text = "x" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer * AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                            Repeat")
                    gen.AppendLine("                                If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                                If AOEFaction = CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    Else
                        gen.AppendLine("                                If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    End If
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                                NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                                AOETarget = NewTarget")
                    gen.AppendLine("                                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                                TotalAmt = TotalAttribute * AttributeAmt")
                    gen.AppendLine("                                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                            Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra2.Text = "/" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer / AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                            Repeat")
                    gen.AppendLine("                                If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                                If AOEFaction = CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    Else
                        gen.AppendLine("                                If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    End If
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                                NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                                AOETarget = NewTarget")
                    gen.AppendLine("                                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                                TotalAmt = TotalAttribute / AttributeAmt")
                    gen.AppendLine("                                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                            Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                End If
            End If
        End If

        If frmEditor.atrN3.Text = "" Then
        Else
            gen.AppendLine("                AttributeName$ = " + Chr(34) + frmEditor.atrN3.Text + Chr(34))
            gen.AppendLine("                AttributeAmt# = " + frmEditor.atrAm3.Text)
            If frmEditor.atrt3.Text = "Self" Then
                If frmEditor.atra3.Text = "+/-" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute + AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra3.Text = "x" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute * AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra3.Text = "/" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute / AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                End If
            ElseIf frmEditor.atrt3.Text = "Target" Then
                If frmEditor.chkTarget.Checked = True Then
                    If frmEditor.atra3.Text = "+/-" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute + AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    ElseIf frmEditor.atra3.Text = "x" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute * AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    ElseIf frmEditor.atra3.Text = "/" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute / AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                End If
            ElseIf frmEditor.atrt3.Text = "AOE" Then 'atriman
                If frmEditor.atra3.Text = "+/-" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer + AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                    Repeat")
                    gen.AppendLine("                        If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                            If AOEFaction = CasterFaction")
                        gen.AppendLine("                                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                Else")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                EndIf")
                        gen.AppendLine("                            EndIf")
                    Else
                        gen.AppendLine("                            If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                Else")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                EndIf")
                        gen.AppendLine("                            EndIf")
                    End If
                    gen.AppendLine("                        EndIf")
                    gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                        AOETarget = NewTarget")
                    gen.AppendLine("                        TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                        TotalAmt = TotalAttribute + AttributeAmt")
                    gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                        AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                    Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra3.Text = "x" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer * AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                            Repeat")
                    gen.AppendLine("                                If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                                If AOEFaction = CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    Else
                        gen.AppendLine("                                If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    End If
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                                NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                                AOETarget = NewTarget")
                    gen.AppendLine("                                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                                TotalAmt = TotalAttribute * AttributeAmt")
                    gen.AppendLine("                                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                            Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra2.Text = "/" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer / AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                            Repeat")
                    gen.AppendLine("                                If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                                If AOEFaction = CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    Else
                        gen.AppendLine("                                If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    End If
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                                NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                                AOETarget = NewTarget")
                    gen.AppendLine("                                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                                TotalAmt = TotalAttribute / AttributeAmt")
                    gen.AppendLine("                                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                            Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                End If
            End If
        End If

        If frmEditor.atrN4.Text = "" Then
        Else
            gen.AppendLine("                AttributeName$ = " + Chr(34) + frmEditor.atrN4.Text + Chr(34))
            gen.AppendLine("                AttributeAmt# = " + frmEditor.atrAm4.Text)
            If frmEditor.atrt4.Text = "Self" Then
                If frmEditor.atra4.Text = "+/-" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute + AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra4.Text = "x" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute * AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra4.Text = "/" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute / AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                End If
            ElseIf frmEditor.atrt4.Text = "Target" Then
                If frmEditor.chkTarget.Checked = True Then
                    If frmEditor.atra4.Text = "+/-" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute + AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    ElseIf frmEditor.atra4.Text = "x" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute * AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    ElseIf frmEditor.atra4.Text = "/" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute / AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                End If
            ElseIf frmEditor.atrt4.Text = "AOE" Then 'atriman
                If frmEditor.atra4.Text = "+/-" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer + AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                    Repeat")
                    gen.AppendLine("                        If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                            If AOEFaction = CasterFaction")
                        gen.AppendLine("                                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                Else")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                EndIf")
                        gen.AppendLine("                            EndIf")
                    Else
                        gen.AppendLine("                            If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                Else")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                EndIf")
                        gen.AppendLine("                            EndIf")
                    End If
                    gen.AppendLine("                        EndIf")
                    gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                        AOETarget$ = NewTarget")
                    gen.AppendLine("                        TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                        TotalAmt = TotalAttribute + AttributeAmt")
                    gen.AppendLine("                        AOEFaction = HomeFaction(AOETarget)")
                    gen.AppendLine("                        AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                    Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra4.Text = "x" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer * AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                            Repeat")
                    gen.AppendLine("                                If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                                If AOEFaction = CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    Else
                        gen.AppendLine("                                If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    End If
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                                NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                                AOETarget = NewTarget")
                    gen.AppendLine("                                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                                TotalAmt = TotalAttribute * AttributeAmt")
                    gen.AppendLine("                                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                            Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra4.Text = "/" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer / AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                            Repeat")
                    gen.AppendLine("                                If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                                If AOEFaction = CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    Else
                        gen.AppendLine("                                If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    End If
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                                NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                                AOETarget = NewTarget")
                    gen.AppendLine("                                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                                TotalAmt = TotalAttribute / AttributeAmt")
                    gen.AppendLine("                                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                            Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                End If
            End If
        End If

        If frmEditor.atrN5.Text = "" Then
        Else
            gen.AppendLine("                AttributeName$ = " + Chr(34) + frmEditor.atrN5.Text + Chr(34))
            gen.AppendLine("                AttributeAmt# = " + frmEditor.atrAm5.Text)
            If frmEditor.atrt5.Text = "Self" Then
                If frmEditor.atra5.Text = "+/-" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute + AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra5.Text = "x" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute * AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra5.Text = "/" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute / AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                End If
            ElseIf frmEditor.atrt5.Text = "Target" Then
                If frmEditor.chkTarget.Checked = True Then
                    If frmEditor.atra5.Text = "+/-" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute + AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    ElseIf frmEditor.atra5.Text = "x" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute * AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    ElseIf frmEditor.atra5.Text = "/" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute / AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                End If
            ElseIf frmEditor.atrt5.Text = "AOE" Then 'atriman
                If frmEditor.atra5.Text = "+/-" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer + AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                    Repeat")
                    gen.AppendLine("                        If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                            If AOEFaction = CasterFaction")
                        gen.AppendLine("                                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                Else")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                EndIf")
                        gen.AppendLine("                            EndIf")
                    Else
                        gen.AppendLine("                            If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                Else")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                EndIf")
                        gen.AppendLine("                            EndIf")
                    End If
                    gen.AppendLine("                        EndIf")
                    gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                        AOETarget = NewTarget")
                    gen.AppendLine("                        TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                        TotalAmt = TotalAttribute + AttributeAmt")
                    gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                        AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                    Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra5.Text = "x" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer * AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                            Repeat")
                    gen.AppendLine("                                If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                                If AOEFaction = CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    Else
                        gen.AppendLine("                                If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    End If
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                                NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                                AOETarget = NewTarget")
                    gen.AppendLine("                                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                                TotalAmt = TotalAttribute * AttributeAmt")
                    gen.AppendLine("                                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                            Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra5.Text = "/" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer / AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                            Repeat")
                    gen.AppendLine("                                If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                                If AOEFaction = CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    Else
                        gen.AppendLine("                                If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    End If
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                                NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                                AOETarget = NewTarget")
                    gen.AppendLine("                                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                                TotalAmt = TotalAttribute / AttributeAmt")
                    gen.AppendLine("                                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                            Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                End If
            End If
        End If

        If frmEditor.atrN6.Text = "" Then
        Else
            gen.AppendLine("                AttributeName$ = " + Chr(34) + frmEditor.atrN6.Text + Chr(34))
            gen.AppendLine("                AttributeAmt# = " + frmEditor.atrAm6.Text)
            If frmEditor.atrt6.Text = "Self" Then
                If frmEditor.atra6.Text = "+/-" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute + AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra6.Text = "x" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute * AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra6.Text = "/" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute / AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                End If
            ElseIf frmEditor.atrt6.Text = "Target" Then
                If frmEditor.chkTarget.Checked = True Then
                    If frmEditor.atra6.Text = "+/-" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute + AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    ElseIf frmEditor.atra6.Text = "x" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute * AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    ElseIf frmEditor.atra6.Text = "/" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute / AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                End If
            ElseIf frmEditor.atrt6.Text = "AOE" Then 'atriman
                If frmEditor.atra6.Text = "+/-" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer + AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                    Repeat")
                    gen.AppendLine("                        If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                            If AOEFaction = CasterFaction")
                        gen.AppendLine("                                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                Else")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                EndIf")
                        gen.AppendLine("                            EndIf")
                    Else
                        gen.AppendLine("                            If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                Else")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                EndIf")
                        gen.AppendLine("                            EndIf")
                    End If
                    gen.AppendLine("                        EndIf")
                    gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                        AOETarget = NewTarget")
                    gen.AppendLine("                        TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                        TotalAmt = TotalAttribute + AttributeAmt")
                    gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                        AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                    Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra6.Text = "x" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer * AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                            Repeat")
                    gen.AppendLine("                                If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                                If AOEFaction = CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    Else
                        gen.AppendLine("                                If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    End If
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                                NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                                AOETarget = NewTarget")
                    gen.AppendLine("                                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                                TotalAmt = TotalAttribute * AttributeAmt")
                    gen.AppendLine("                                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                            Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra6.Text = "/" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer / AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                            Repeat")
                    gen.AppendLine("                                If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                                If AOEFaction = CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    Else
                        gen.AppendLine("                                If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    End If
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                                NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                                AOETarget = NewTarget")
                    gen.AppendLine("                                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                                TotalAmt = TotalAttribute / AttributeAmt")
                    gen.AppendLine("                                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                            Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                End If
            End If
        End If

        If frmEditor.atrN7.Text = "" Then
        Else
            gen.AppendLine("                AttributeName$ = " + Chr(34) + frmEditor.atrN7.Text + Chr(34))
            gen.AppendLine("                AttributeAmt# = " + frmEditor.atrAm7.Text)
            If frmEditor.atrt7.Text = "Self" Then
                If frmEditor.atra7.Text = "+/-" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute + AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra7.Text = "x" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute * AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra7.Text = "/" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute / AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                End If
            ElseIf frmEditor.atrt7.Text = "Target" Then
                If frmEditor.chkTarget.Checked = True Then
                    If frmEditor.atra7.Text = "+/-" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute + AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    ElseIf frmEditor.atra7.Text = "x" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute * AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    ElseIf frmEditor.atra7.Text = "/" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute / AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                End If
            ElseIf frmEditor.atrt7.Text = "AOE" Then 'atriman
                If frmEditor.atra7.Text = "+/-" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer + AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                    Repeat")
                    gen.AppendLine("                        If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                            If AOEFaction = CasterFaction")
                        gen.AppendLine("                                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                Else")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                EndIf")
                        gen.AppendLine("                            EndIf")
                    Else
                        gen.AppendLine("                            If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                Else")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                EndIf")
                        gen.AppendLine("                            EndIf")
                    End If
                    gen.AppendLine("                        EndIf")
                    gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                        AOETarget = NewTarget")
                    gen.AppendLine("                        TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                        TotalAmt = TotalAttribute + AttributeAmt")
                    gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                        AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                    Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra7.Text = "x" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer * AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                            Repeat")
                    gen.AppendLine("                                If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                                If AOEFaction = CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    Else
                        gen.AppendLine("                                If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    End If
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                                NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                                AOETarget = NewTarget")
                    gen.AppendLine("                                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                                TotalAmt = TotalAttribute * AttributeAmt")
                    gen.AppendLine("                                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                            Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra7.Text = "/" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer / AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                            Repeat")
                    gen.AppendLine("                                If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                                If AOEFaction = CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    Else
                        gen.AppendLine("                                If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    End If
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                                NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                                AOETarget = NewTarget")
                    gen.AppendLine("                                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                                TotalAmt = TotalAttribute / AttributeAmt")
                    gen.AppendLine("                                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                            Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                End If
            End If
        End If

        If frmEditor.atrN8.Text = "" Then
        Else
            gen.AppendLine("                AttributeName$ = " + Chr(34) + frmEditor.atrN8.Text + Chr(34))
            gen.AppendLine("                AttributeAmt# = " + frmEditor.atrAm8.Text)
            If frmEditor.atrt8.Text = "Self" Then
                If frmEditor.atra8.Text = "+/-" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute + AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra8.Text = "x" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute * AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra8.Text = "/" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute / AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                End If
            ElseIf frmEditor.atrt8.Text = "Target" Then
                If frmEditor.chkTarget.Checked = True Then
                    If frmEditor.atra8.Text = "+/-" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute + AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    ElseIf frmEditor.atra8.Text = "x" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute * AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    ElseIf frmEditor.atra8.Text = "/" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute / AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                End If
            ElseIf frmEditor.atrt8.Text = "AOE" Then 'atriman
                If frmEditor.atra8.Text = "+/-" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer + AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                    Repeat")
                    gen.AppendLine("                        If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                            If AOEFaction = CasterFaction")
                        gen.AppendLine("                                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                Else")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                EndIf")
                        gen.AppendLine("                            EndIf")
                    Else
                        gen.AppendLine("                            If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                Else")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                EndIf")
                        gen.AppendLine("                            EndIf")
                    End If
                    gen.AppendLine("                        EndIf")
                    gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                        AOETarget = NewTarget")
                    gen.AppendLine("                        TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                        TotalAmt = TotalAttribute + AttributeAmt")
                    gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                        AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                    Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra8.Text = "x" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer * AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                            Repeat")
                    gen.AppendLine("                                If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                                If AOEFaction = CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    Else
                        gen.AppendLine("                                If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    End If
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                                NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                                AOETarget = NewTarget")
                    gen.AppendLine("                                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                                TotalAmt = TotalAttribute * AttributeAmt")
                    gen.AppendLine("                                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                            Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra8.Text = "/" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer / AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                            Repeat")
                    gen.AppendLine("                                If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                                If AOEFaction = CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    Else
                        gen.AppendLine("                                If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    End If
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                                NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                                AOETarget = NewTarget")
                    gen.AppendLine("                                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                                TotalAmt = TotalAttribute / AttributeAmt")
                    gen.AppendLine("                                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                            Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                End If
            End If
        End If

        If frmEditor.atrN9.Text = "" Then
        Else
            gen.AppendLine("                AttributeName$ = " + Chr(34) + frmEditor.atrN9.Text + Chr(34))
            gen.AppendLine("                AttributeAmt# = " + frmEditor.atrAm9.Text)
            If frmEditor.atrt9.Text = "Self" Then
                If frmEditor.atra9.Text = "+/-" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute + AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra9.Text = "x" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute * AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra9.Text = "/" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute / AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                End If
            ElseIf frmEditor.atrt9.Text = "Target" Then
                If frmEditor.chkTarget.Checked = True Then
                    If frmEditor.atra9.Text = "+/-" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute + AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    ElseIf frmEditor.atra9.Text = "x" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute * AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    ElseIf frmEditor.atra9.Text = "/" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute / AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                End If
            ElseIf frmEditor.atrt9.Text = "AOE" Then 'atriman
                If frmEditor.atra9.Text = "+/-" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer + AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                    Repeat")
                    gen.AppendLine("                        If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                            If AOEFaction = CasterFaction")
                        gen.AppendLine("                                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                Else")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                EndIf")
                        gen.AppendLine("                            EndIf")
                    Else
                        gen.AppendLine("                            If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                Else")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                EndIf")
                        gen.AppendLine("                            EndIf")
                    End If
                    gen.AppendLine("                        EndIf")
                    gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                        AOETarget = NewTarget")
                    gen.AppendLine("                        TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                        TotalAmt = TotalAttribute + AttributeAmt")
                    gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                        AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                    Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra9.Text = "x" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer * AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                            Repeat")
                    gen.AppendLine("                                If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                                If AOEFaction = CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    Else
                        gen.AppendLine("                                If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    End If
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                                NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                                AOETarget = NewTarget")
                    gen.AppendLine("                                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                                TotalAmt = TotalAttribute * AttributeAmt")
                    gen.AppendLine("                                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                            Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra9.Text = "/" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer / AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                            Repeat")
                    gen.AppendLine("                                If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                                If AOEFaction = CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    Else
                        gen.AppendLine("                                If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    End If
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                                NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                                AOETarget = NewTarget")
                    gen.AppendLine("                                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                                TotalAmt = TotalAttribute / AttributeAmt")
                    gen.AppendLine("                                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                            Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                End If
            End If
        End If

        If frmEditor.atrN10.Text = "" Then
        Else
            gen.AppendLine("                AttributeName$ = " + Chr(34) + frmEditor.atrN10.Text + Chr(34))
            gen.AppendLine("                AttributeAmt# = " + frmEditor.atrAm10.Text)
            If frmEditor.atrt10.Text = "Self" Then
                If frmEditor.atra10.Text = "+/-" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute + AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra10.Text = "x" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute * AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra10.Text = "/" Then
                    gen.AppendLine("                TotalAttribute = Attribute(Player, AttributeName)")
                    gen.AppendLine("                TotalAmt = TotalAttribute / AttributeAmt")
                    gen.AppendLine("                If TotalAmt >= TotalAttribute")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                Else")
                    gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                    gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                    gen.AppendLine("                EndIf")
                End If
            ElseIf frmEditor.atrt10.Text = "Target" Then
                If frmEditor.chkTarget.Checked = True Then
                    If frmEditor.atra10.Text = "+/-" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute + AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    ElseIf frmEditor.atra10.Text = "x" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute * AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    ElseIf frmEditor.atra10.Text = "/" Then
                        gen.AppendLine("                TotalAttribute = Attribute(Target, AttributeName)")
                        gen.AppendLine("                TotalAmt = TotalAttribute / AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Target, TotalAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingnumber(Target, TotalAmt, 255, 0, 0)")
                        gen.AppendLine("                SetAttribute(Target, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                End If
            ElseIf frmEditor.atrt10.Text = "AOE" Then 'atriman
                If frmEditor.atra10.Text = "+/-" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer + AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                    Repeat")
                    gen.AppendLine("                        If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                            If AOEFaction = CasterFaction")
                        gen.AppendLine("                                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                Else")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                EndIf")
                        gen.AppendLine("                            EndIf")
                    Else
                        gen.AppendLine("                            If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                Else")
                        gen.AppendLine("                                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                    SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                EndIf")
                        gen.AppendLine("                            EndIf")
                    End If
                    gen.AppendLine("                        EndIf")
                    gen.AppendLine("                        NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                        AOETarget = NewTarget")
                    gen.AppendLine("                        TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                        TotalAmt = TotalAttribute + AttributeAmt")
                    gen.AppendLine("                        AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                        AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                    Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra10.Text = "x" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer * AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                            Repeat")
                    gen.AppendLine("                                If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                                If AOEFaction = CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    Else
                        gen.AppendLine("                                If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    End If
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                                NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                                AOETarget = NewTarget")
                    gen.AppendLine("                                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                                TotalAmt = TotalAttribute * AttributeAmt")
                    gen.AppendLine("                                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                            Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                ElseIf frmEditor.atra10.Text = "/" Then
                    gen.AppendLine("                AOETarget = NextActorInZone(Player)")
                    gen.AppendLine("                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    If target = "Allies" Then
                        gen.AppendLine("                TotalAttributePlayer = Attribute(Player, AttributeName)")
                        gen.AppendLine("                TotalAmtPlayer = TotalAttributePlayer / AttributeAmt")
                        gen.AppendLine("                If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                Else")
                        gen.AppendLine("                    CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                    SetAttribute(Player, AttributeName, TotalAmt)")
                        gen.AppendLine("                EndIf")
                    End If
                    gen.AppendLine("                If Player <> AOETarget")
                    gen.AppendLine("                            Repeat")
                    gen.AppendLine("                                If AOEDistance <= Range")
                    If frmEditor.chkTarget.Checked = True Then
                        gen.AppendLine("                                If AOEFaction = CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    Else
                        gen.AppendLine("                                If AOEFaction <> CasterFaction")
                        gen.AppendLine("                                    If TotalAmt >= TotalAttribute")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 0, 255, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    Else")
                        gen.AppendLine("                                        CreateFloatingNumber(Player, AttributeAmt, 255, 0, 0)")
                        gen.AppendLine("                                        SetAttribute(AOETarget, AttributeName, TotalAmt)")
                        gen.AppendLine("                                    EndIf")
                        gen.AppendLine("                                EndIf")
                    End If
                    gen.AppendLine("                                EndIf")
                    gen.AppendLine("                                NewTarget = NextActorInZone(AOETarget)")
                    gen.AppendLine("                                AOETarget = NewTarget")
                    gen.AppendLine("                                TotalAttribute = Attribute(AOETarget, AttributeName)")
                    gen.AppendLine("                                TotalAmt = TotalAttribute / AttributeAmt")
                    gen.AppendLine("                                AOEFaction$ = HomeFaction(AOETarget)")
                    gen.AppendLine("                                AOEDistance = ActorDistance(Player, AOETarget)")
                    gen.AppendLine("                            Until Player = AOETarget")
                    gen.AppendLine("                EndIf")
                End If
            End If
        End If


        '
        If frmEditor.chkTarget.Checked = True Then
            gen.AppendLine("        EndIf")
            gen.AppendLine("    EndIf")
            gen.AppendLine("EndIf")
        End If
        gen.AppendLine(" ")
        gen.AppendLine("Return")
        gen.AppendLine("End Function")

        Return gen.ToString
    End Function
End Class