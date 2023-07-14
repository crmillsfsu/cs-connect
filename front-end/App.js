import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View } from 'react-native';
import { Card } from 'react-native-paper';
import Logo from './components/Logo';

export default function App() {
  return (
    <View style={styles.container}>
      <Text>Welcome to the app</Text>
      <Card>
        <Logo/>
      </Card>
      <StatusBar style="auto" />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
