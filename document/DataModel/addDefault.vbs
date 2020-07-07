Option   Explicit    
ValidationMode   =   True    
InteractiveMode   =   im_Batch    
  
Dim   mdl   '   the   current   model    
  
'   get   the   current   active   model    
Set   mdl   =   ActiveModel    
If   (mdl   Is   Nothing)   Then    
      MsgBox   "There   is   no   current   Model "    
ElseIf   Not   mdl.IsKindOf(PdPDM.cls_Model)   Then    
      MsgBox   "The   current   model   is   not   an   Physical   Data   model. "    
Else    
      ProcessFolder   mdl    
End   If    
  
Private   sub   ProcessFolder(folder)    
On Error Resume Next   
      Dim   Tab   'running     table    
      for   each   Tab   in   folder.tables    
            if   not   tab.isShortcut   then    
                  'if tab.comment="" then
                     'tab.comment   =  tab.name
                  'end if   
                  Dim isNeedAdd:isNeedAdd = true
                  Dim isNeedAddId:isNeedAddId = true
                  Dim   col   '   running   column    
                  for   each   col   in   tab.columns    
                     if col.code="CreationTime" then   
                         isNeedAdd = false   
                     end if  
    
                     if col.code="Id" then   
                         isNeedAddId = false   
                     end if  
                  next
                  if isNeedAddId then
                     Set col = tab.columns.CreateNew 
                     If not col is Nothing then
                        col.name = "标识"
                        col.code = "Id"
                        col.comment = "标识"
                        col.DataType = "char(6)"
                        output " col.name: " + col.name
                     End If
                     set col = nothing
                  End if
                  if isNeedAdd then
                     Set col = tab.columns.CreateNew 
                     If not col is Nothing then
                        col.name = "创建时间"
                        col.code = "CreationTime"
                        col.comment = "创建时间"
                        col.DataType = "datetime(6)"
                        output " col.name: " + col.name
                     End If
                     set col = nothing
                     
                     Set col = tab.columns.CreateNew 
                     If not col is Nothing then
                        col.name = "创建人标识"
                        col.code = "CreatorId"
                        col.comment = "创建人标识"
                        col.DataType = "char(36)"
                        output " col.name: " + col.name
                     End If
                     set col = nothing
                     
                     Set col = tab.columns.CreateNew 
                     If not col is Nothing then
                        col.name = "最后修改时间"
                        col.code = "LastModificationTime"
                        col.comment = "最后修改时间"
                        col.DataType = "datetime(6)"
                        output " col.name: " + col.name
                     End If
                     set col = nothing
                     
                     Set col = tab.columns.CreateNew 
                     If not col is Nothing then
                        col.name = "最后修改人标识"
                        col.code = "LastModifierId"
                        col.comment = "最后修改时间"
                        col.DataType = "char(36)"
                        output " col.name: " + col.name
                     End If
                     set col = nothing
                  end if  
            end   if    
      next    
  
      Dim   view   'running   view    
      for   each   view   in   folder.Views    
            if   not   view.isShortcut   then    
                  view.name   =   view.comment    
            end   if    
      next    
  
      '   go   into   the   sub-packages    
      Dim   f   '   running   folder    
      For   Each   f   In   folder.Packages    
            if   not   f.IsShortcut   then    
                  ProcessFolder   f    
            end   if    
      Next    
end   sub 
