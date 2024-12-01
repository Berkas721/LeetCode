type TestCaseData = {
  id: number;
  input: string;
  output: string;
};

type TestCaseResult = {
  testCaseData: TestCaseData
  resultStatus: number;
  date: string;
  usedTime: number;
  usedMemory: number;
  errorMessage: string | null;
  incorrectAnswer: string | null;
};

type SolutionResult = {
  solutionId: number;
  runTestCaseResults: TestCaseResult[];
  isPassed: boolean;
  isErrorAppear: boolean;
  isWrongAnswerAppear: boolean;
};

type SolutionSummary = {
  solutionId: number;
  isPassed: boolean;
  totalUsedTime: number;
  totalUsedMemory: number;
  testCaseResultWithError: TestCaseResult | null;
  testCaseResultWithWrongAnswer: TestCaseResult | null;
};