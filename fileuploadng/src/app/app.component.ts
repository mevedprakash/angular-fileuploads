import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  title = 'fileuploadng';
  filePreview!: any;
  file!: any;
  httpClient = inject(HttpClient);
  onFileChange(event: any) {
    this.file = event.target.files[0];
    console.log(event.target.files[0]);
    this.filePreview = URL.createObjectURL(this.file);
  }
  upload() {
    let formData = new FormData();
    formData.append('files', this.file);
    this.httpClient
      .post('https://localhost:7189/File/upload', formData)
      .subscribe(() => {
        console.log('uploaded');
      });
  }
}
