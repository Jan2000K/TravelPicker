import React from 'react'
import ReactDOM from 'react-dom/client'
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";
import {IndexPage} from "./pages/IndexPage/IndexPage";
import { LoginPage } from './pages/LoginPage/LoginPage';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import appRoutes from './models/AppRoutes';
import { MyLocationsPage } from './pages/MyLocationsPage/MyLocationsPage';

const router = createBrowserRouter([
  {
    path: appRoutes.index,
    element: <IndexPage />,
    
  },
  {
    path:appRoutes.login,
    element:<LoginPage />
  },
  {
    path:appRoutes.myLocations,
    element:<MyLocationsPage />
  }
]);
const queryClient = new QueryClient()
ReactDOM.createRoot(document.getElementById('root') as HTMLElement).render(
  <React.StrictMode>
    <QueryClientProvider client={queryClient}>
     <RouterProvider router={router} />
     </QueryClientProvider>
  </React.StrictMode>,
)
