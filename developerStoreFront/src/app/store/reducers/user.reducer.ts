import { createReducer, on } from '@ngrx/store';
import { setUser } from '../actions/user.actions';
import { UserModel } from 'src/app/Model/user.model';

export interface UserState {
  user: UserModel | null;
}

export const initialState: UserState = {
  user: null,
};

export const userReducer = createReducer(
  initialState,
  on(setUser, (state, { user }) => ({ ...state, user }))
);
