clc, clear, close all
% Parameters
Fs = 1000;              % Sampling frequency (Hz)
t = 0:1/Fs:1;     % Time vector (1 second)
f = 3;                 % Frequency of sine wave (Hz)

% Create a sinusoidal signal
signal = 2*sin(2*pi*f*t);

% Add noise to the signal
noisy_signal = signal + 0.5*randn(size(t));

% Design a low-pass filter
fc = 10;               % Cutoff frequency (Hz)
[b, a] = butter(4, fc/(Fs/2)); % 4th order Butterworth filter

% Apply zero-phase filtering
filtered_signal = filtfilt(b, a, noisy_signal);


subplot(2,1,1);
plot(t, noisy_signal);
title('Noisy Signal');
xlabel('Time (s)');
ylabel('Amplitude');
ylim([-3, 3])

subplot(2,1,2);
plot(t, filtered_signal);
title('Zero-Phase Filtered Signal');
xlabel('Time (s)');
ylabel('Amplitude');
ylim([-3, 3])
