import { Box, Flex, Heading } from '@chakra-ui/react';
import React, { useState } from 'react';
import { colors } from '../../colors';
import BudgetSelector from './BudgetSelector';
import { NavTarget } from './nav-target';
import NavItem from './NavItem';
import NavItemList from './NavItemList';
import { useNavigate } from 'react-router-dom';

export interface SideNavProps {
    navItems: NavTarget[];
}

export const SideNav: React.FC<SideNavProps> = ({ navItems }) => {
    const navigate = useNavigate();

    return (
        <Flex
            flexDir="column"
            height="100vh"
            width={{ base: '300px' }}
            backgroundColor={colors.BG_MAIN}
        >
            <Heading
                cursor="pointer"
                _hover={{ opacity: 0.8 }}
                transition="all 0.3s ease-in-out"
                textAlign="center"
                marginTop="1rem"
                color={colors.NORMAL_TEXT}
                onClick={() => navigate('/')}
            >
                BudgetPal
            </Heading>
            <BudgetSelector styles={{ marginTop: '2rem' }} />
            <NavItemList navItems={navItems} />
        </Flex>
    );
};
