import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { ItemService } from 'src/app/core/services/item.service'; // Importe o ItemService

@Component({
  selector: 'app-edit-item',
  templateUrl: './edit-item.component.html',
  styleUrls: ['./edit-item.component.scss'],
})
export class EditItemComponent implements OnInit {
  editItemForm: FormGroup;
  itemId!: string | null;

  constructor(
    private fb: FormBuilder,
    private itemService: ItemService,
    private route: ActivatedRoute,
    private router: Router,
    private snackBar: MatSnackBar
  ) {
    this.editItemForm = this.fb.group({
      productId: ['', Validators.required],
      categoria: ['', Validators.required],
      image: ['', Validators.required],
      unitPrice: [0, [Validators.required, Validators.min(0)]],
      stockQuantity: [0, [Validators.required, Validators.min(0)]],
    });
  }

  ngOnInit(): void {
    this.itemId = this.route.snapshot.paramMap.get('id');

    if (this.itemId) {
      this.itemService.getItemById(this.itemId).subscribe((item) => {
        this.editItemForm.patchValue(item);
      });
    }
  }

  onSubmit(): void {
    if (this.editItemForm.valid && this.itemId) {
      const editItem = {
        id: this.itemId,
        ...this.editItemForm.value,
      };
      const updatedItem = { ...editItem, id: this.itemId };
      this.itemService.updateItem(this.itemId, updatedItem).subscribe(() => {
        this.openSnackBar('Item atualizado com sucesso!');
        setTimeout(() => this.router.navigate(['/manage-items']), 2000);
      });
    }
  }

  cancel(): void {
    this.router.navigate(['/manage-items']);
  }

  openSnackBar(message: string) {
    this.snackBar.open(message, 'Fechar', {
      duration: 3000,
    });
  }
}
