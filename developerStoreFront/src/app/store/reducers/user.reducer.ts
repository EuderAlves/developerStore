import { createReducer, on } from '@ngrx/store';
import { setUser } from '../actions/user.actions';
import { User } from '../../core/models/user.model';

export interface UserState {
  user: User | null;
}

export const initialState: UserState = {
  user: null,
};

export const userReducer = createReducer(
  initialState,
  on(setUser, (state, { user }) => ({ ...state, user }))
);
