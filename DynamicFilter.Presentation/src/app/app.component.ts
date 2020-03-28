import { Component, OnInit, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from './services/api.service';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';


export interface DialogData {
  licenseKey: string;
  message: ""
}
@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styles: []
})
export class AppComponent implements OnInit {
  title = 'DynamicFilter-Presentation';

  isProductActivated: boolean;
  licenseChecked = false;
  
  constructor(r: Router, public apiService: ApiService, public dialog: MatDialog) {
  }

  public ngOnInit(): void {
    this.checkLicense("");
  }

    public activateLicense(productKey: string): void {
    this.apiService.activateLicense(productKey).subscribe(result => {
      if(result) {
        this.checkLicense("")
      }
      return result;
    });
  }

  public checkLicense(dialogMessage: string) {
    this.apiService.checkLicense().subscribe(result => {
      this.isProductActivated = result;
      this.licenseChecked = true;
      if(!result) {
        this.openDialog(dialogMessage);
      }
    });
  }

  openDialog(message: string): void {
    const dialogRef = this.dialog.open(ActivateLicenseDialog, {
      width: '500px',
      data: {licenseKey: "", message: message}
    });

    dialogRef.afterClosed().subscribe(result => {
      this.checkLicense("Key invalid")
    });
  }

}

@Component({
  selector: 'activate-license-dialog',
  templateUrl: 'activate-license-dialog.html',
})
export class ActivateLicenseDialog {

  public isLoading = false;

  constructor(
    public dialogRef: MatDialogRef<ActivateLicenseDialog>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData,
    public api: ApiService) {}

  onNoClick(): void {
    this.dialogRef.close();
  }
  
  onOkClick(): void {
    this.isLoading = true;
    this.api.activateLicense(this.data.licenseKey).subscribe(response => {
      this.isLoading = false;
      this.dialogRef.close();
    }, error => {
      this.isLoading = false;
      this.dialogRef.close();
    })
  }

}