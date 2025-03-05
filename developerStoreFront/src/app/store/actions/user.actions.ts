import { createAction, props } from '@ngrx/store';
import { UserModel } from 'src/app/Model/user.model';

export const setUser = createAction(
  '[User] Set User',
  props<{ user: UserModel }>()
);
