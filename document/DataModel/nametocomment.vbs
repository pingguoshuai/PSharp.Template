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


'   This   routine   copy   name   into   comment   for   each   table,   each   column   and   each   view 
'   of   the   current   folder 
Private   sub   ProcessFolder(folder) 
      Dim   Tab   'running     table 
      for   each   Tab   in   folder.tables 
            if   not   tab.isShortcut   then 
                  tab.comment   =   tab.name 
                  Dim   col   '   running   column 
                  for   each   col   in   tab.columns 
                        col.comment=   col.name 
                  next 
            end   if 
      next


      Dim   view   'running   view 
      for   each   view   in   folder.Views 
            if   not   view.isShortcut   then 
                  view.comment   =   view.name 
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
