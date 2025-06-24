import React from 'react';
import { Outlet } from 'react-router-dom';
import NavBar from './NavBar';

const LayoutConNav = () => {
    return (
        <>
            <NavBar />
            <div style={{ paddingTop: '56px' }}>
                <Outlet />
            </div>
        </>
    );
};

export default LayoutConNav;
