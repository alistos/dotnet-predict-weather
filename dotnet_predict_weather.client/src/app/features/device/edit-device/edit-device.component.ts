import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { DeviceService } from '../services/device.service';
import { Device } from '../models/device.model';
import { EditDeviceRequest } from '../models/edit-device-request.model';

@Component({
  selector: 'app-edit-device',
  templateUrl: './edit-device.component.html',
  styleUrls: ['./edit-device.component.css']
})
export class EditDeviceComponent implements OnInit, OnDestroy {

  id: string | null = null;
  paramSubscription?: Subscription;
  editDeviceSubscription?: Subscription;
  deleteDeviceSubscription?: Subscription;
  device?: Device;
  constructor(private route: ActivatedRoute, private deviceService: DeviceService, private router: Router) {

  }
   

  ngOnInit(): void {
    this.paramSubscription = this.route.paramMap.subscribe({
      next: (params) => {
        this.id = params.get('id');

        if (this.id) {
          //get the data from the API for this device id
          this.deviceService.getDeviceById(this.id).subscribe({
            next: (response) => {
              this.device = response;
            }
          })
        }
      }
    })
  }

  onFormSubmit(): void {
    const editDeviceRequest: EditDeviceRequest = {
      manufacturer: this.device?.manufacturer ?? '',
      url: this.device?.url ?? '',
      commands: this.device?.commands.toString() ?? '',
    }

    //pass this object to service
    if (this.id) {
      this.editDeviceSubscription = this.deviceService.editDevice(this.id, editDeviceRequest).subscribe({
        next: (response) => {
          this.router.navigateByUrl('/usermenu/device');
        }
      });
    }  
  }

  onDelete(): void {
    if (this.id) {
      this.deleteDeviceSubscription = this.deviceService.deleteDevice(this.id).subscribe({
        next: (response) => {
          this.router.navigateByUrl('/usermenu/device');
        }
      });
    }
  }

  ngOnDestroy(): void {
    this.paramSubscription?.unsubscribe();
    this.editDeviceSubscription?.unsubscribe();
    this.deleteDeviceSubscription?.unsubscribe();
  }
}
