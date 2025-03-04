import { createAction, props } from '@ngrx/store';
import { User } from '../../core/models/user.model';

export const setUser = createAction('[User] Set User', props<{ user: User }>());
