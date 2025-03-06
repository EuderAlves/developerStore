import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ItemService } from 'src/app/core/services/item.service'; // Importe o ItemService
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-item',
  templateUrl: './add-item.component.html',
  styleUrls: ['./add-item.component.scss'],
})
export class AddItemComponent {
  addItemForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private itemService: ItemService,
    private router: Router,
    private snackBar: MatSnackBar
  ) {
    this.addItemForm = this.fb.group({
      productId: ['', Validators.required],
      categoria: ['', Validators.required],
      image: ['', Validators.required],
      unitPrice: [0, [Validators.required, Validators.min(0)]],
      stockQuantity: [0, [Validators.required, Validators.min(0)]],
    });
  }

  onSubmit(): void {
    if (this.addItemForm.valid) {
      const addItem = {
        id: 'new',
        ...this.addItemForm.value,
      };
      this.itemService.addItem(addItem).subscribe(() => {
        this.openSnackBar('Item adicionado com sucesso!');
        setTimeout(() => this.router.navigate(['/manage-items']), 1000);
      });
    }
  }
  openSnackBar(message: string) {
    this.snackBar.open(message, 'Fechar', {
      duration: 3000,
    });
  }

  cancel(): void {
    this.router.navigate(['/manage-items']);
  }
}
