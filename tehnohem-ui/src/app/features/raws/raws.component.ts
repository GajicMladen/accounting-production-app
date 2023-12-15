import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { InternalDocumentsDialogComponent } from 'src/app/shared/components/dialogs/internal-documents-dialog/internal-documents-dialog.component';
import { RawType } from 'src/app/shared/model/enums/rawType';

import {InternalDocumentType } from 'src/app/shared/model/enums/invoiceType';
import { InternalDocumentData } from 'src/app/shared/model/internalDocumentsData';
import { Raw } from 'src/app/shared/model/raw';
import { RawService } from 'src/app/shared/services/raw-service/raw.service';
import { AddNewRawComponent } from './components/add-new-raw/add-new-raw.component';

@Component({
  selector: 'app-raws',
  templateUrl: './raws.component.html',
  styleUrls: ['./raws.component.css']
})
export class RawsComponent implements OnInit {
  
    raws: Raw[] = [];
    bottles: Raw[] = [];
    caps: Raw[] = [];
    labels : Raw[] = [];

    rawTypes = RawType;
  
    dialogData : InternalDocumentData ={
      title:"Ulazna faktura",
      documentType:InternalDocumentType.INCOMING_INVOICE,
      isReadonly:false
    }
  
  constructor( public dialog:MatDialog,
    private rawService: RawService
  ) { }


  ngOnInit(): void {
    this.updateRaws();
  }

  updateRaws(){
    this.rawService.getAllRaws().subscribe(
      allRaws=>{
        this.raws = allRaws.filter(r => r.rawType! === RawType.RAW);
        this.bottles = allRaws.filter( r => r.rawType! === RawType.BOTTLE);
        this.caps = allRaws.filter( r => r.rawType! === RawType.CAP);
        this.labels = allRaws.filter( r => r.rawType! === RawType.LABEL);
      }
    )
  }

  addIncomingInovice(){
    
    this.dialogData={
      title:"Ulazna faktura",
      documentType:InternalDocumentType.INCOMING_INVOICE,
      isReadonly:false
    }
    const dialogRef = this.dialog.open(InternalDocumentsDialogComponent,{
      data:this.dialogData
    });
    dialogRef.afterClosed().subscribe(data =>{
      if(data== "addedNewInvoice")
        this.updateRaws();
    })
    
  }

  addIssuePaper(){
    
    this.dialogData={
      title:"Izdatnica repromaterijala",
      documentType:InternalDocumentType.INTERNAL_ISSUE_RAW,
      isReadonly:false
    }

    const dialogRef = this.dialog.open(InternalDocumentsDialogComponent,{
      data:this.dialogData
    }); 
    
    dialogRef.afterClosed().subscribe(
      data=>{
        if(data === "addedNewInternalIssueRaw")
        this.updateRaws();
      }
    );

  }

  addNewRaw(rawType:RawType){
    const dialogRefAddNewRaw = this.dialog.open( AddNewRawComponent ,{
      data : {
        rawType: rawType,
        raw: undefined,
        update: false,
      }
    })
    dialogRefAddNewRaw.afterClosed().subscribe(
      data=>{
        if(data === "addedNewRaw")
        this.updateRaws();
      }
    );
  }

  deleteRaw(rawId : number){
    this.rawService.deleteRaw(rawId).subscribe(
      data=>{
        this.updateRaws();
      }

    )
  }

  editRaw(raw: Raw){
    const dialogRefEditRaw = this.dialog.open( AddNewRawComponent ,{
      data : {
        rawType: raw.rawType,
        raw: raw,
        update: true,
      }
    })
    dialogRefEditRaw.afterClosed().subscribe(
      data=>{
        if(data === "editedRaw")
        this.updateRaws();
      }
    );
  }
}
