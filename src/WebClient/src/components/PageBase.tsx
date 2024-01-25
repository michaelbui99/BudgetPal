import { HStack } from '@chakra-ui/layout';
import React from 'react';
import { SideNav } from './Navbar/Navbar';
import { NavTarget } from './Navbar/nav-target';
import { Flex } from '@chakra-ui/react';

interface PageBaseProps {
    children?: React.ReactNode;
    styles?: React.CSSProperties;
}

const PageBase: React.FC<PageBaseProps> = ({ children }) => {
    const navItems: NavTarget[] = [
        {
            name: 'Budget',
            redirectTo: '/budget',
        },
    ];

    return (
        <Flex flexDir="row">
            <SideNav navItems={navItems} />
            {children}
        </Flex>
    );
};

export default PageBase;
