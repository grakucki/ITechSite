
InsertIgnoreDataMember "../AspNetRoles.cs", "public virtual ICollection<ItechUsers> ItechUsers"

InsertIgnoreDataMember "../Dokument.cs", "public virtual ICollection<InformationPlan> InformationPlan"

InsertIgnoreDataMember "../InformationPlan.cs", "public virtual Resource ResourceWorkstation"
InsertIgnoreDataMember "../InformationPlan.cs", "public virtual Resource ResourceModel"

'InsertIgnoreDataMember "../ITechModel.cs", ""
'InsertIgnoreDataMember "../ItechUsers.cs", ""

InsertIgnoreDataMember "../Kategorie.cs", "public virtual ICollection<Dokument> Dokument"

InsertIgnoreDataMember "../ModelsWorkstation.cs", "public virtual Resource Workstation"
InsertIgnoreDataMember "../ModelsWorkstation.cs", "public virtual Resource Models "


InsertIgnoreDataMember "../News.cs", "public virtual Resource Resource"

'InsertIgnoreDataMember "../NewsPriority.cs", ""
'InsertIgnoreDataMember "../Resource.cs", ""
'InsertIgnoreDataMember "../SimaticCpuType.cs", ""

InsertIgnoreDataMember "../Workstation.cs", "public virtual Resource Resource"

'InsertIgnoreDataMember "../WorkstationGroup.cs", ""

'InsertIgnoreDataMember "../.cs", ""



Function InsertString(strFileName , strFindText, strInsertText)

'	strFileName = "text.txt"
'	strFindText = "kota"
'	strInsertText = "[System.Runtime.Serialization.IgnoreDataMember]"
	
	Const ForReading = 1
	Const ForWriting = 2

		
	Set objFSO = CreateObject("Scripting.FileSystemObject")
	Set objFile = objFSO.OpenTextFile(strFileName, ForReading)
	
	source = objFile.ReadAll
	objFile.Close
	
	Set objFile = objFSO.OpenTextFile("out.txt", ForWriting)
		objFile.WriteLine source 
		objFile.Close

	i = InStr(source, strFindText)


	if i>0 then
		strNewText =  Mid(source, 1, i-1) & strInsertText & Mid(source, i, Len(source)-i+1)

		Set objFile = objFSO.OpenTextFile(strFileName, ForWriting)
		objFile.WriteLine strNewText
		objFile.Close
	else
		MsgBox("Nie odnaleziono w " & strFileName )

	End If

End Function


Function InsertIgnoreDataMember(strFileName2, strFindText2)
	call InsertString(strFileName2, strFindText2, "[System.Runtime.Serialization.IgnoreDataMember]" & chr(13) & chr(10) & chr(9) )
End Function
