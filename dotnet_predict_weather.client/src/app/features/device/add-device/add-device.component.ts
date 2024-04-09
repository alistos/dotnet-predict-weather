import { Component, OnDestroy } from '@angular/core';
import { AddDeviceRequest } from '../models/add-device-request-model';
import { DeviceService } from '../services/device.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-device',
  templateUrl: './add-device.component.html',
  styleUrls: ['./add-device.component.css']
})
export class AddDeviceComponent implements OnDestroy {

  model: AddDeviceRequest;
  private addDeviceSubscription?: Subscription

  constructor(private deviceService: DeviceService, private router: Router) {
    this.model = {
      manufacturer: '',
      url: '',
      commands: '',
    }
  }

  onFormSubmit() {
    this.addDeviceSubscription = this.deviceService.addDevice(this.model).subscribe({
      next: (response) => {
        this.router.navigateByUrl('/usermenu/device')
      },
    });
  }

  ngOnDestroy(): void {
    this.addDeviceSubscription?.unsubscribe();
  }

}
